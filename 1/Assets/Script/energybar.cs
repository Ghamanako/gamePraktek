using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class energybar : MonoBehaviour
{
    public Image energybar1;
    public float energy;
    public float energystart;
    
    public void UseEnergy(int useenergy)
    {
        energy = energy - useenergy;
        energybar1.fillAmount = energy / energystart;
    }
}
