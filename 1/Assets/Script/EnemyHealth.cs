using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float EHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float amnt)
    {
        EHealth -= amnt;
        if (EHealth < 0)
        {
            print("enemy has died!!!");
        }
        print("Enemy took some damage ");
    }
}
