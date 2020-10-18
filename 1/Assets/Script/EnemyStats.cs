using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int healthLevel = 10;
    public int maxHealth;
    public int CurrentHealth;

    public Animator animator;

    void Start()
    {
        maxHealth = SetMaxHealthFromHealthLevel();
        CurrentHealth = maxHealth;
       
    }


    private int SetMaxHealthFromHealthLevel()
    {
        maxHealth = healthLevel * 10;
        return maxHealth;
    }

    public void TakeDamage(int Damage)
    {
        CurrentHealth = CurrentHealth - Damage;


        animator.SetTrigger("Damage");
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            animator.SetBool("Die", true);
        }
    }

    public void ExitTriggerrr(int noDAmage)
    {
        animator.SetTrigger("nodamage");
    }


}
