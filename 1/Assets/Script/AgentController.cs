using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace SVS
{
    public class AgentController : MonoBehaviour
    {
        IInput input;
        AgentMovement movement; 
        // Start is called before the first frame update
        private void OnEnable()
        {
            input = GetComponent<IInput>();
            movement = GetComponent<AgentMovement>();
            input.OnMovementDirectionInput += movement.HandleMovementDirection;
            input.OnMovementInput += movement.HandleMovement;
        }

        private void OnDisable()
        {
            input.OnMovementDirectionInput -= movement.HandleMovementDirection;
            input.OnMovementInput -= movement.HandleMovement;
        }
    }
}