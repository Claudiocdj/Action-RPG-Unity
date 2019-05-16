using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour {

    public float speed;

    protected Rigidbody2D myRigidbody;
    protected Animator myAnimator;

    protected virtual void Start() {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    public virtual void Move(Vector3 newPos) {
        //myRigidbody.velocity = Vector3.zero;

        transform.position = (Vector3.MoveTowards(transform.position,
                                                  newPos,
                                                  speed * Time.deltaTime));
    }

    public void SetAnimations(Vector3 moveInput) {
        if (moveInput == Vector3.zero)
            myAnimator.SetBool("isMoving", false);
        else {
            myAnimator.SetFloat("moveX", moveInput.x);
            myAnimator.SetFloat("moveY", moveInput.y);
            myAnimator.SetBool("isMoving", true);
        }
    }
}
