using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState {
    nothing,
    attack,
    interact
}

public class Player : Creature {

    public PlayerState currentState;

    private Rigidbody2D myRigidbody;
    private Animator myAnimator;

    protected override void Start() {
        base.Start();

        myRigidbody = GetComponent<Rigidbody2D>();

        myAnimator = GetComponent<Animator>();

        currentState = PlayerState.nothing;
    }

    public override void Move(Vector3 moveInput) {
        if (moveInput == Vector3.zero) {
            myAnimator.SetBool("isMoving", false);

            return;
        }

        moveInput.Normalize();

        myRigidbody.MovePosition(transform.position + (moveInput * speed * Time.deltaTime));

        myAnimator.SetFloat("moveX", moveInput.x);

        myAnimator.SetFloat("moveY", moveInput.y);

        myAnimator.SetBool("isMoving", true);
    }

    public override void Damage(int damage) {
        base.Damage(damage);
    }
}
