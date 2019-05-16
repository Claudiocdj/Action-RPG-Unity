using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour {

    public GameObject[] attacks;

    public float attackDelay;
    public float distanceToInitAttack;

    private float timer;
    private GameObject player;
    private EnemyScript enemy;

    void Start() {
        timer = 0f;

        player = GameObject.FindWithTag("Player").gameObject;
        enemy = GetComponent<EnemyScript>();
    }
    
    void Update() {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        
        if (timer >= attackDelay && distance < distanceToInitAttack) {
            int n = Random.Range(0, attacks.Length);

            GameObject obj = Instantiate(attacks[n], transform.position, Quaternion.identity);

            Vector3 direction = player.transform.position - transform.position;

            direction = direction.normalized;

            //obj.GetComponent<RockAttackScript>().direction = direction;

            timer = 0;
        }
        else
            timer += Time.deltaTime;
    }
}
