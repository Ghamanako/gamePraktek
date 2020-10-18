using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowManager : MonoBehaviour
{
    public Material Glow, nonGlow;
    public bool isGlowing = false;

   
   
    public void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            
                isGlowing = true;
                gameObject.GetComponent<MeshRenderer>().material = Glow;
                
        }
        
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            isGlowing = false;
            gameObject.GetComponent<MeshRenderer>().material = nonGlow;
            
        }
    }
}
