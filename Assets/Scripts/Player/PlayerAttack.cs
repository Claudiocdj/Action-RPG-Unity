using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public int attackForce;

    private bool canAttack;
    private InputsMove playerMove;
    private Animator myAnimator;

    private void Start() {
        playerMove = GetComponent<InputsMove>();
        myAnimator = GetComponent<Animator>();

        canAttack = true;
    }

    private void Update() {
        if (Input.GetButtonDown("Fire1") && canAttack) {
            StartCoroutine(AttackMoviment());
        }
    }

    private IEnumerator AttackMoviment() {
        playerMove.enabled = canAttack = false;

        myAnimator.SetBool("isAttacking", true);

        yield return new WaitForSeconds(.34f);

        playerMove.enabled = canAttack = true;

        myAnimator.SetBool("isAttacking", false);
    }


}
