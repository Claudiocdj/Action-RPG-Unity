using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonEnemy : MonoBehaviour{

    public int rateInSeconds;
    public float minDistToSummon;
    public Vector2[] pos;
    public GameObject enemy;

    private float timer;
    private float distToPlayer;
    private Transform player;

    private void Start() {
        timer = 0f;

        player = GameObject.FindWithTag("Player").transform;
    }

    void Update() {
        float distToPlayer = Vector3.Distance(player.transform.position, transform.position);

        if (timer > rateInSeconds && distToPlayer <= minDistToSummon) {
            timer = 0f;

            int randPos = Random.Range(0, pos.Length + 1);

            Instantiate(enemy, pos[randPos], Quaternion.identity);
        }
        else timer += Time.deltaTime;
    }
}
