using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    private float ForwardInput;
    private float RightInput;

    private Vector3 velocity;

   
    
    public cameraCOntroller cameraC;
    public characterMovement CharacterMovement;
    public AnimationController animationController;
    void Update()
    {

    }

    public void AddMovement(float forward, float right)
    {
        ForwardInput = forward;
        RightInput = right;

        Vector3 camFwd = cameraC.transform.forward;
        Vector3 camRight = cameraC.transform.right;

        Vector3 translation = forward * cameraC.transform.forward;
        translation += right * cameraC.transform.right;
        translation.y = 0;
        if (translation.magnitude > 0)
        {
            velocity = translation;
        }
        else
        {
            velocity = Vector3.zero;
        }
        CharacterMovement.Velocity = translation;
    }

    internal void Jump()
    {
        if (Physics.Linecast(transform.position, transform.position + new Vector3(0, -9, 0)))
        {
            CharacterMovement.Jump();
            animationController.Jump();
            CharacterMovement.onLanded += animationController.Land;
        }
        
    }

    public void Attack()
    {
       
        animationController.Attack();
    }
    
    public void Attack2()
    {
        animationController.Attack2();
    }
    
   

    public float getVelocity()
    {
        return CharacterMovement.Velocity.magnitude;
    }

    public void ToggleRun()
    {
        if (CharacterMovement.GetMovementMode() != MovementMode.Running)
        {
            CharacterMovement.setMovementMode(MovementMode.Running);
            
        }
        else
        {
            CharacterMovement.setMovementMode(MovementMode.Walking);
           
        }
    }

    public void ToggleSprint(bool enable)
    {
        if(enable)
        {
            CharacterMovement.setMovementMode(MovementMode.Sprinting);
           
        }
        else
        {
            CharacterMovement.setMovementMode(MovementMode.Running);
            
        }
    }
}
