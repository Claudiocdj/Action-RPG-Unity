using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAttackScript : Attack {
    public float speed;

    private Rigidbody2D myRigidbody;

    void Start(){
        myRigidbody = GetComponent<Rigidbody2D>();

        float angle = Vector2.Angle(direction, new Vector2(0f,1f));
        
        transform.eulerAngles = new Vector3(0, 0, FindDegree(direction.x, direction.y));

        direction = direction.normalized * speed;
        
        myRigidbody.AddForce(direction, ForceMode2D.Impulse);

        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Destroy(gameObject);
    }

    public static float FindDegree(float x, float y) {
        float value = (float)((Mathf.Atan2(x, y) / System.Math.PI) * -180f);
        if (value < 0) value += 360f;

        return value;
    }
}
