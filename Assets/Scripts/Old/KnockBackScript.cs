using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackScript : MonoBehaviour {

    public float force;
    public float effectTime;

    private Rigidbody2D myRigidbody;

    public void KnockBackEffect(Collider2D collision) {
        myRigidbody = GetComponent<Rigidbody2D>();

        Vector2 difference = transform.position - collision.transform.position;

        difference = difference.normalized * force;

        myRigidbody.AddForce(difference, ForceMode2D.Impulse);

        StartCoroutine(KnockBackEffect());
    }

    private IEnumerator KnockBackEffect() {
        yield return new WaitForSeconds(effectTime);

        myRigidbody.velocity = Vector2.zero;
    }
}
