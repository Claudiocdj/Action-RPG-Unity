using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAttackScript : Attack {
    public float speed;

    private Rigidbody2D myRigidbody;

    void Start(){
        myRigidbody = GetComponent<Rigidbody2D>();

        direction = direction.normalized * speed;

        myRigidbody.AddForce(direction, ForceMode2D.Impulse);

        Destroy(gameObject, 30f);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Destroy(gameObject);
    }
}
