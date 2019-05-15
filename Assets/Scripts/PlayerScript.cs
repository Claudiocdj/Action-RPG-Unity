using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState {
    walk,
    attack,
    interact
}

public class PlayerScript : MonoBehaviour {

    public float speed;
    public float health;

    private Rigidbody2D myRigidbody;
    private Animator myAnimator;

    private Vector3 moveInput;
    private PlayerState currentState;

    private void Start() {
        currentState = PlayerState.walk;

        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();

        myAnimator.SetFloat("moveX", 0);
        myAnimator.SetFloat("moveY", -1);
    }

    private void Update() {
        moveInput = Vector3.zero;

        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Fire1") && currentState != PlayerState.attack)
            StartCoroutine(AttackMovement());
        
        if(currentState == PlayerState.walk)
            UpdateMoveAndAnimation();
    }

    private IEnumerator AttackMovement() {
        currentState = PlayerState.attack;
        myAnimator.SetBool("isAttacking", true);

        yield return new WaitForSeconds(.34f);

        currentState = PlayerState.walk;
        myAnimator.SetBool("isAttacking", false);
    }

    private void UpdateMoveAndAnimation() {
        if (moveInput != Vector3.zero) {
            moveInput.Normalize();

            myRigidbody.MovePosition(transform.position + (moveInput * speed * Time.deltaTime));

            myAnimator.SetFloat("moveX", moveInput.x);
            myAnimator.SetFloat("moveY", moveInput.y);
            myAnimator.SetBool("isMoving", true);
        }

        else
            myAnimator.SetBool("isMoving", false);
    }

    /*
    public int playerSpeed = 10;
    public GameObject atk;

    private Rigidbody2D rb2d;
    private Animator anim;
    
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }
	
	void Update () {
        rb2d.velocity = Vector2.zero;

        float xDir = Input.GetAxisRaw("Horizontal");
        float yDir = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Fire1"))
            Attack(xDir, yDir);

        rb2d.velocity = new Vector2(xDir, yDir) * playerSpeed;

        anim.SetFloat("moveX", xDir);
        anim.SetFloat("moveY", yDir);

        if (xDir != 0 || yDir != 0) {
            anim.SetFloat("lastMoveX", xDir);
            anim.SetFloat("lastMoveY", yDir);
        }
    }

    private void Attack(float xDir, float yDir) {
        Vector3 shotDir = setShotDirection(xDir,yDir);

        var atkInst = Instantiate(atk, transform.position + shotDir, Quaternion.identity);
        atkInst.GetComponent<AttackScript>().SetDir(shotDir.x * 1.25f, shotDir.y * 1.25f); //0.8 * 1.25 = 1.0f
    }

    private Vector3 setShotDirection(float xDir, float yDir) {
        float lastMoveX = anim.GetFloat("lastMoveX");
        float lastMoveY = anim.GetFloat("lastMoveY");
        Vector3 shotDir = Vector3.zero;

        if (xDir == 0f || lastMoveX == 0f) {
            if (lastMoveY > 0f || yDir > 0f)
                shotDir = new Vector2(0f, 0.8f);

            else if (lastMoveY < 0f || yDir < 0f)
                shotDir = new Vector2(0f, -0.8f);
        }

        if (yDir == 0f || lastMoveY == 0f) {
            if (lastMoveX > 0f || xDir > 0f)
                shotDir = new Vector2(0.8f, 0f);

            else if (lastMoveX < 0f || xDir < 0f)
                shotDir = new Vector2(-0.8f, 0f);
        }

        else if (xDir > 0) {
            if (yDir > 0)
                shotDir = new Vector2(0.8f, 0.8f);

            else
                shotDir = new Vector2(0.8f, -0.8f);
        }

        else if (xDir < 0) {
            if (yDir > 0)
                shotDir = new Vector2(-0.8f, 0.8f);

            else
                shotDir = new Vector2(-0.8f, -0.8f);
        }

        return shotDir;
    }
    */
}
