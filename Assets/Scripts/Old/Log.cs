using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Creature {

    private Transform player;
    private Animator myAnimator;
    private bool isSleeping;

    protected override void Start() {
        base.Start();

        player = GameObject.FindWithTag("Player").transform;

        myAnimator = GetComponent<Animator>();

        myAnimator.SetBool("sleeping", true);

        isSleeping = true;
    }

    public override void Move(Vector3 moveInput) {

    }

}
