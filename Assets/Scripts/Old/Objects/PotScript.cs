using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotScript : MonoBehaviour {

    public GameObject loot;

    private Animator myAnimator;
    private BoxCollider2D myBoxCollider;

    private void Start() {
        myAnimator = GetComponent<Animator>();
        myBoxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("PlayerAttack")) {
            myAnimator.SetBool("destroy", true);
            
            myBoxCollider.enabled = false;

            StartCoroutine(DestroyPot());
        }
    }

    private IEnumerator DestroyPot() {
        yield return new WaitForSeconds(0.5f);

        if(loot != null)
            Instantiate(loot, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(60f);

        Destroy(gameObject);
    }

}
