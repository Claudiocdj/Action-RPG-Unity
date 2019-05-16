using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float distance = 0f;
    public float speed = 3f;
    public int health = 3;

    private Transform playerTransform;
    private Animator anim;
    private Rigidbody2D rb2d;
    private SpriteRenderer sprite;
    private CapsuleCollider2D collider;
    private LifeBar lifebar;

    // Use this for initialization
    void Start () {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<CapsuleCollider2D >();
        lifebar = GetComponentInChildren<LifeBar>().GetComponent<LifeBar>(); ;
    }
	
	// Update is called once per frame
	void Update () {
        rb2d.velocity = Vector2.zero;
        if (Vector3.Distance(transform.position, playerTransform.position) > distance) {
            Vector2 newPosition = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
            float xDir = newPosition.x - transform.position.x;
            float yDir = newPosition.y - transform.position.y;
            
            anim.SetFloat("moveX", xDir);
            anim.SetFloat("moveY", yDir);

            if (xDir != 0 || yDir != 0) {
                anim.SetFloat("lastMoveX", xDir);
                anim.SetFloat("lastMoveY", yDir);
            }

            transform.position = newPosition;
        } else {
            anim.SetFloat("moveX", 0f);
            anim.SetFloat("moveY", 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {

        if (col.CompareTag("Attack"))
            DamageEnemy();

    }

    IEnumerator DamageEffect() {

        float actualSpeed = speed;
        speed *= -1;
        sprite.color = Color.red;

        rb2d.AddForce(new Vector2(0f, 200f));

        yield return new WaitForSeconds(0.1f);

        speed = actualSpeed;
        sprite.color = Color.white;
    }

    IEnumerator DestroyEnemy(GameObject go) {
        yield return new WaitForSeconds(0.1f);

        Debug.Log(gameObject.name);
        Destroy(go);
    }


    void DamageEnemy() {
        health--;
        //lifebar.setLifeBar(health);

        StartCoroutine(DamageEffect());

        if (health < 1) {
            collider.isTrigger = true;
            StartCoroutine(DestroyEnemy(gameObject));
        }
    }
}
