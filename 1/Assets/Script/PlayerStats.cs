using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
  public int healthLevel = 10;
  public int maxHealth;
  public int CurrentHealth;

    public bool PowerUp = false;
  
   
    

    public AnimationController animationController;
  public energybar energybar;
       

 public PlayerHealth playerHealth;
       
     
 void Start()
 {
  maxHealth = SetMaxHealthFromHealthLevel();
  CurrentHealth = maxHealth;
  playerHealth.SetMaxHealth(maxHealth);
        PowerUp = false;
 }

     
 private int SetMaxHealthFromHealthLevel()
 {
   maxHealth = healthLevel * 10;
   return maxHealth;
 }

        public void TakeDamage(int Damage)
        {
            CurrentHealth = CurrentHealth - Damage;
            playerHealth.SetCurrentHealth(CurrentHealth);

            animationController.TakeDamage();
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            animationController.Died();
        }
        }

    public void healer(int healing)
    {
       CurrentHealth = CurrentHealth += healing;
       energybar.UseEnergy(10);
       Debug.Log("Healing");
       playerHealth.SetCurrentHealth(CurrentHealth);
    }
    

    public void ExitTriggerrr(int noDAmage)
    {
        animationController.noDamage();
    }
    
}
