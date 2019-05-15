using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockAttackScript : MonoBehaviour {

    public float speed;

    public Vector3 direction;
    private Rigidbody2D myRigidbody;

    void Start(){
        myRigidbody = GetComponent<Rigidbody2D>();

        direction = direction.normalized * speed;

        myRigidbody.AddForce(direction, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Destroy(gameObject);
    }
}
