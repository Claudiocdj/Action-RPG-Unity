using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExclamationMark : MonoBehaviour
{
    private SpriteRenderer mySprite;

    private void Start() {
        mySprite = GetComponent<SpriteRenderer>();

        mySprite.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        mySprite.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        mySprite.enabled = false;
    }
}
