using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : Life {

    public float KnockBackForce;
    public float KnockBackTime;

    private Rigidbody2D myRigidbody;

    protected override void Start(){
        base.Start();
    }

    public override void Damage(int damage, Collider2D collision) {
        base.Damage(damage,collision);
        
        KnockBackEffect(collision);
    }

    public void KnockBackEffect(Collider2D collision) {
        myRigidbody = GetComponent<Rigidbody2D>();

        Vector2 difference = transform.position - collision.transform.position;

        difference = difference.normalized * KnockBackForce;

        myRigidbody.AddForce(difference, ForceMode2D.Impulse);

        StartCoroutine(KnockBackEffect());
    }

    private IEnumerator KnockBackEffect() {
        yield return new WaitForSeconds(KnockBackTime);

        myRigidbody.velocity = Vector2.zero;
    }
}
