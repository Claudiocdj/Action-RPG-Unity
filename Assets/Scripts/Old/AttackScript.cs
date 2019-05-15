using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour {

    public int vel;
    private Vector2 dir = new Vector2(0f,0f);
    private Rigidbody2D rb;
    
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        if(dir.x != 0 || dir.y != 0)
            rb.velocity = new Vector2(vel * dir.x, vel * dir.y);
    }

    private void OnTriggerEnter2D(Collider2D col) {
        DestroyObject(gameObject,0f);
    }
    
    public void SetDir(float x, float y) {
        dir = new Vector2(x, y);
    }
}
