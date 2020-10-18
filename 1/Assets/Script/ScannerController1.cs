using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ScannerController1 : MonoBehaviour
{

    public Material Glow, nonGlow;
    public bool isGlowing = false;



    public void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {

            isGlowing = true;
           
            gameObject.GetComponent<SkinnedMeshRenderer>().material = Glow;
        }

    }

    public void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            isGlowing = false;
            
            gameObject.GetComponent<SkinnedMeshRenderer>().material = nonGlow;
        }
    }
}