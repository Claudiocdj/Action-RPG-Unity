using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepDistanceMove : ChasePlayerMove {

    public float maxDistToPlayer;

    protected override void Start() {
        base.Start();
    }

    protected override void Update() {
        base.Update();
    }

    protected override void ChasePlayer(float distToPlayer) {
        Vector3 newPos = (transform.position - player.transform.position).normalized;

        newPos = (newPos * maxDistToPlayer) + player.transform.position;

        Move(newPos);
    }
}
