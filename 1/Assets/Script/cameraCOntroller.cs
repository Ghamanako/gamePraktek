using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraCOntroller : MonoBehaviour
{
    public float CameraSmoothingFactor=1;
    public float LookUPMax = 60;
    public float LookUPMin = -60;

    private Quaternion camRotation;

    void Start()
    {
        camRotation = transform.localRotation;   
    }

    void Update()
    {
        camRotation.x += Input.GetAxis("Mouse Y") * CameraSmoothingFactor*(-1);
        camRotation.y += Input.GetAxis("Mouse X") * CameraSmoothingFactor;

        camRotation.x = Mathf.Clamp(camRotation.x, LookUPMin, LookUPMax);

        transform.localRotation = Quaternion.Euler(camRotation.x, camRotation.y, camRotation.z);
    }
}
