using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Moveable))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private Moveable moveable;

    void Start()
    {
        animator = GetComponent<Animator>();
        moveable = GetComponent<Moveable>();
    }

    void Update()
    {
        animator.SetFloat("xDirection", moveable.animateDirect().x);
    }
}
