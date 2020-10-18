using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(character))]
public class AnimationController : MonoBehaviour
{
    public Animator animator;

    private float speed;
    private character CHaracter;

    void Start()
    {
        CHaracter = GetComponent<character>();

       
    }

    void Update()
    {
        if (animator == null)
        {
            Debug.LogWarning("No Valid Animation");
            return;
        }
        speed = Mathf.SmoothStep(speed, CHaracter.getVelocity(),Time.deltaTime*25);
        animator.SetFloat("velocity", speed);
    }

    public void SetMovementMode(MovementMode mode)
    {
       
        switch (mode)
        {
            case MovementMode.Walking:
                {
                    animator.SetInteger("movement State", 0);
                    break;
                }
            case MovementMode.Running:
                {
                    animator.SetInteger("movement State", 0);
                    break;
                }

            case MovementMode.Sprinting:
                {
                    animator.SetInteger("movement State", 1);
                    break;
                }
        }
    }

    internal void Jump()
    {
        animator.SetTrigger("Jump");
    }

    public void Land()
    {
        animator.SetTrigger("Land");
    }

    public void TakeDamage()
    {
        animator.SetBool("Damage",true);
    }
    public void noDamage()
    {
        animator.SetBool("Damage", false);
    }

    public void Died()
    {
        animator.SetBool("Die", true);
    }


    internal void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            animator.SetTrigger("Attack1");

        }
    }

    internal void Attack2()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            animator.SetTrigger("Attack2");
        }
    }
}
