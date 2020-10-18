using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2 :MonoBehaviour
{
    private Transform player;
    private float dist;
    public float speed;
    public float HowClose;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;   
    }

    void Update()
    {
        dist = Vector3.Distance(player.position, transform.position);

        if (dist <= HowClose)
        {
            transform.LookAt(player);
            GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        }

        //for melee attack or shoot
        if (dist <= 1.5f)
        {
            //do damage
        }
    }
}
