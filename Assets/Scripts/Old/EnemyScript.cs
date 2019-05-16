using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : CreaturesScript {

    public int secondsInvunerable;
    public bool isInvunerable = false;

    public KnockBackScript myKnockBa;

    private SpriteRenderer mySprite;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Attack") && !isInvunerable) {
            StartCoroutine(DamageEffect());

            FloatingHitController.CreateFloatingHit("1", transform);

            if (myKnockBa != null)
                myKnockBa.KnockBackEffect(collision);

            health--;

            if (health <= 0) Destroy(gameObject);
        }
    }
    
    private IEnumerator DamageEffect() {
        isInvunerable = true;

        mySprite = GetComponent<SpriteRenderer>();
        
        for(int i = 0; i < secondsInvunerable*5; i++) {
            mySprite.color = Color.red;
            yield return new WaitForSeconds(.1f);
            mySprite.color = Color.white;
            yield return new WaitForSeconds(.1f);
        }

        isInvunerable = false;
    }
}
