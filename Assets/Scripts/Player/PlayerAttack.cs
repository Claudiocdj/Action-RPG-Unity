using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public int attackForce;

    private InputsMove playerMove;
    private Animator myAnimator;

    private void Start() {
        playerMove = GetComponent<InputsMove>();
        myAnimator = GetComponent<Animator>();
    }

    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            StartCoroutine(AttackMoviment());
        }
    }

    private IEnumerator AttackMoviment() {
        playerMove.enabled = false;

        myAnimator.SetBool("isAttacking", true);

        yield return new WaitForSeconds(.34f);

        playerMove.enabled = true;

        myAnimator.SetBool("isAttacking", false);
    }


}
