using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrowAttack : MonoBehaviour {

    public int attackForce;
    public GameObject attackPrefab;
    public float delayTime;
    
    private InputsMove playerMove;
    private Animator myAnimator;
    private float timer;

    void Start() {
        playerMove = GetComponent<InputsMove>();
        myAnimator = GetComponent<Animator>();

        timer = 0f;
    }
    
    void Update() {
        if (Input.GetButtonDown("Fire2") && timer > delayTime) {
            StartCoroutine(Attack());
            timer = 0f;
        }
        else timer += Time.deltaTime;
    }

    private IEnumerator Attack() {
        playerMove.enabled = false;

        GameObject obj = Instantiate(attackPrefab, transform.position, Quaternion.identity);

        float x = myAnimator.GetFloat("moveX");
        float y = myAnimator.GetFloat("moveY");

        Vector3 direction = new Vector3(x, y, transform.position.z);

        direction = direction.normalized;

        obj.GetComponent<Attack>().direction = direction;
        obj.GetComponent<Attack>().force = attackForce;

        yield return new WaitForSeconds(.34f);

        playerMove.enabled = true;
    }
}
