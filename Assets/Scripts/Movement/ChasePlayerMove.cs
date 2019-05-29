using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChasePlayerMove : Movement {

    public float minDistForChase;

    protected Transform player;
    protected float distToPlayer;

    protected override void Start() {
        base.Start();

        player = GameObject.FindWithTag("Player").transform;
    }

    protected virtual void Update() {
        distToPlayer = Vector3.Distance(player.transform.position, transform.position);

        if (distToPlayer <= minDistForChase)
            ChasePlayer(distToPlayer);
        else
            SetAnimations(Vector3.zero);
    }

    protected abstract void ChasePlayer(float distToPlayer);
}
