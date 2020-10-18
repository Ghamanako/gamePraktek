using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(character))]
[RequireComponent(typeof(characterMovement))]
public class movement : MonoBehaviour
{
    private character Character;
    private characterMovement characterMovement;
    
    void Start()
    {
        Character = GetComponent<character>();
        characterMovement = GetComponent<characterMovement>();
        
    }

    void Update()
    {
        Character.AddMovement(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Character.ToggleRun();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Character.ToggleSprint(true);
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            Character.ToggleSprint(false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Character.Jump();
        }
        if (Input.GetMouseButtonDown(0))
        {
            Character.Attack();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Character.Attack2();
        }

       

    }
}
