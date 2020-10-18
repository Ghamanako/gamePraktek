using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class triggerZone : MonoBehaviour
    {
        

    public int Damage = 25;
    public int noDamage = 0;
    void Start()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.TakeDamage(Damage);
            }
        }

    private void OnTriggerExit(Collider other)
    {
        PlayerStats playerStats = other.GetComponent<PlayerStats>();
        if (playerStats != null)
        {
            playerStats.ExitTriggerrr(noDamage);
        }
    }

}
