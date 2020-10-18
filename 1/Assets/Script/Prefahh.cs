using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefahh : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject bullet;
    public Transform gun;
    public float shootrate=0f;
    public float shootForce=0f;
    private float shootrateTImeStamp=0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Time.time > shootrateTImeStamp)
            {
                GameObject go = (GameObject)Instantiate(bullet, gun.position, gun.rotation);
                go.GetComponent<Rigidbody>().AddForce(gun.forward * shootForce);
                shootrateTImeStamp = Time.time + shootrate;
            }
        }
    }
}
