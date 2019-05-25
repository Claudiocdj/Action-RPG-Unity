using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDoor : MonoBehaviour {

    public Sprite openDoorSprite;

    private bool isOpen;

    private void Start() {
        isOpen = false;
    }

    public void OpenDoor() {
        GetComponent<SpriteRenderer>().sprite = openDoorSprite;

        GetComponent<BoxCollider2D>().isTrigger = true;

        isOpen = true;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") && isOpen) {
            SceneManager.LoadScene("BossScene");

            Transform playerPos = GameObject.Find("Player").GetComponent<Transform>();

            playerPos.position = new Vector3(0.5f, -24f, playerPos.position.z);
        }
    }
}
