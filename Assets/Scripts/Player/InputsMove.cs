using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputsMove : Movement {
    
    protected override void Start() {
        base.Start();

        DontDestroyOnLoad(gameObject);
    }
    
    protected virtual void Update() {
        Vector3 moveInput = Vector3.zero;

        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        if (myAnimator != null) SetAnimations(moveInput);

        Move(moveInput.normalized + transform.position);
    }
}
