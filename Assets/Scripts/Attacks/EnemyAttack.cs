using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public int enemyHitForce;
    public float rateAttackInSeconds;
    public float minDistToAttack;
    public float maxDistToAttack;
    public GameObject attackPrefab;

    private float rate, minDist, maxDist;
    private float timer;
    private float dist;
    private GameObject player;

    private void Start() {
        rate = rateAttackInSeconds;
        minDist = minDistToAttack;
        maxDist = maxDistToAttack;

        player = GameObject.FindWithTag("Player");

        timer = rateAttackInSeconds;
    }

    private void Update() {
        dist = Vector3.Distance(player.transform.position, transform.position);
        
        if (timer > rate && dist >= minDist && dist <= maxDist) {
            Attack();

            timer = 0f;
        }
        else
            timer += Time.deltaTime;
    }

    private void Attack() {
        GameObject obj = Instantiate(attackPrefab, transform.position, Quaternion.identity);

        Vector3 direction = player.transform.position - transform.position;

        direction = direction.normalized;

        obj.GetComponent<Attack>().direction = direction;
        obj.GetComponent<Attack>().force = enemyHitForce;
    }
}
