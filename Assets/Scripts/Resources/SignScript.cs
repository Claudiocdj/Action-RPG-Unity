using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SignScript : MonoBehaviour {

    public string signText;

    private GameObject dialogBox;
    private Text dialogText;
    private bool isNear;

    private void Start() {
        dialogBox = Resources.FindObjectsOfTypeAll(typeof(GameObject))
                             .Cast<GameObject>().Where(g => g.tag == "DialogBox").ToList()[0];
        
        dialogText = dialogBox.transform.GetChild(1).GetComponent<Text>();
    }

    private void Update() {
        if(Input.GetButtonDown("Fire2") && isNear) {
            dialogText.text = signText;

            dialogBox.SetActive(true);
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

            dialogBox.SetActive(false);
        }
    }
}
