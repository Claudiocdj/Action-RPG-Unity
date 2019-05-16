using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageScript : MonoBehaviour {

    public bool isInvunerable;
    public int secondsInvunerable;

    private PlayerScript player;
    private SpriteRenderer mySprite;

    private void Start() {
        player = transform.root.GetComponent<PlayerScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("EnemyAttack") && !isInvunerable) {
            player.health--;

            FloatingHitController.CreateFloatingHit("1", transform);

            if (player.health <= 0) Destroy(gameObject);

            StartCoroutine(DamageEffect());
        }
    }

    private IEnumerator DamageEffect() {
        isInvunerable = true;

        mySprite = transform.root.GetComponent<SpriteRenderer>();

        for (int i = 0; i < secondsInvunerable * 5; i++) {
            mySprite.color = Color.red;
            yield return new WaitForSeconds(.1f);
            mySprite.color = Color.white;
            yield return new WaitForSeconds(.1f);
        }

        isInvunerable = false;
    }
}
