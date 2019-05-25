using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NPCScript : MonoBehaviour {

    public GameObject npcMenuBox;

    private bool isNear;
    private bool isEnabled;
    private InputsMove player;
    
    void Start() {
        isNear = isEnabled = false;

        player = GameObject.Find("Player").GetComponent<InputsMove>();
    }

    void Update() {
        if (Input.GetButtonDown("Fire2") && isNear && !isEnabled) {
            npcMenuBox.SetActive(true);

            player.enabled = false;

            isEnabled = true;
        }

        if (Input.GetButtonDown("Fire1")) {
            npcMenuBox.SetActive(false);

            player.enabled = true;

            isEnabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            isNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            isNear = false;
        }
    }
}
