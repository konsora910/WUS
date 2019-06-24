using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_animation : StateMachineBehaviour
{
    private Animator animator;
    private CharacterController cCon;
    private Vector3 velocity;
    [SerializeField]
    private float walkSpeed;

    void Start()
    {
        animator = GetComponent<Animator>();
        cCon = GetComponent<CharacterController>();
        velocity = Vector3.zero;
    }

    private T GetComponent<T>()
    {
        throw new NotImplementedException();
    }

    void Update()
    {

        //　地面に接地してる時は初期化
        if (cCon.isGrounded)
        {
            animator.GetCurrentAnimatorStateInfo(0).IsName("Walk");

            if ( !animator.IsInTransition(0))
            {
                animator.SetTrigger("Idle");
            }
        }

        velocity.y += Physics.gravity.y * Time.deltaTime;
        cCon.Move(velocity * Time.deltaTime);
    }
}
