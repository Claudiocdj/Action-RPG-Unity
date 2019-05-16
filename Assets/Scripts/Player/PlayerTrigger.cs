using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("EnemyAttack")) {
            int hit = collision.gameObject.GetComponent<Attack>().force;

            transform.root.GetComponent<Life>().Damage(hit, null);
        }

        if (collision.CompareTag("Coin")) {
            gameObject.transform.root.GetComponent<PlayerCoins>().AddCoin(1);
        }
    }

}
