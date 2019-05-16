using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    private Player player;
    private PlayerAttack playerAttack;
    
    private void Start() {
        player = GetComponent<Player>();

        playerAttack = transform.Find("SwordAttack").GetComponent<PlayerAttack>();
    }

    private void Update() {

        Vector3 moveInput = Vector3.zero;

        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        if(player.currentState == PlayerState.nothing)
            player.Move(moveInput);

        //if (Input.GetButtonDown("Fire1") && player.currentState != PlayerState.attack)
            //playerAttack.Attack();
    }
}
