using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogScript : EnemyScript {

    public float distanceToWakeUp;
    public float minDistance;
    
    private Transform player;
    private Animator myAnimator;
    private bool isSleeping;

    protected void Start() {
        
        player = GameObject.FindWithTag("Player").transform;

        myAnimator = GetComponent<Animator>();

        myAnimator.SetBool("sleeping", true);

        isSleeping = true;
    }
    
    void Update() {
        if (DistanceToPlayer() <= distanceToWakeUp) {
            if (isSleeping) StartCoroutine("WakeUp");

            Move();
        }

        else if (!isSleeping) {
            myAnimator.SetBool("sleeping", true);

            isSleeping = true;
        }
    }

    private float DistanceToPlayer() {
        return Vector3.Distance(player.transform.position, transform.position);
    }

    private void Move() {
        Vector3 newPos = (transform.position - player.transform.position).normalized;
        
        newPos = (newPos * minDistance) + player.transform.position;

        transform.position = (Vector3.MoveTowards(transform.position,
                                                  newPos,
                                                  speed * Time.deltaTime));
    }

    private IEnumerator WakeUp() {
        myAnimator.SetBool("sleeping", false);

        yield return new WaitForSeconds(.52f);

        isSleeping = false;
    }
}
