using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour {

    private bool isInvunerable;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("PlayerAttack") && !isInvunerable) {
            StartCoroutine(HiddenTriggers(GetComponent<Life>().secondsInvunerableEffect));
            
            int damage = collision.gameObject.transform.root.
                         GetComponent<PlayerAttack>().attackForce;

            GetComponent<EnemyLife>().Damage(damage, collision);
        }
    }

    private IEnumerator HiddenTriggers(int value) {
        isInvunerable = true;

        yield return new WaitForSeconds(value);

        isInvunerable = false;
    }

}
