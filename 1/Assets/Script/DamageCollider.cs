using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    public int WeapondDamage = 25;
    
    public int powerboost;
    public float CD;
    public int noDamage = 0;

   public void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            WeapondDamage = WeapondDamage + powerboost;
            StartCoroutine(BoostPower());
        }
    }

    IEnumerator BoostPower()
    {
        yield return new WaitForSeconds(CD);
        WeapondDamage = WeapondDamage;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "enemy")
        {
            EnemyStats enemyStats = col.GetComponent<EnemyStats>();
            if (enemyStats != null)
            {
                enemyStats.TakeDamage(WeapondDamage);
            }
        }
        
    }

    
}
