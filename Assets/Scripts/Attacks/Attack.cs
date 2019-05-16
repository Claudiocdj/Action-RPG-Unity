using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour {
    public Vector3 direction;
    public int force;

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Atacou meu menino");
        Destroy(gameObject);
    }
}