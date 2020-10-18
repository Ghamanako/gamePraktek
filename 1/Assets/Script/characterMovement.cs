using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementMode { Walking, Running, Sprinting };

[RequireComponent(typeof(Rigidbody))]
public class characterMovement : MonoBehaviour
{
    public energybar energybar;
   

    public Transform t_mesh;
    public float maxSpeed = 0.1f;
    public float WalkSpeed = 3.3f;
    public float RunSpeed = 6.6f;
    public float SprintSpeed = 10;
    public float dashForce;
    public float dashDuration;
    public float jump_force = 100;
    public float SpeedBoost = 2;
    public float SpeedCd;
    public int healing = 25;
   
    public bool powerUp = false;
 

    public float SmoothSpeed;
    private float RotationSpeed = 10;
    private bool OnGround = true;
    private const int maxJump = 2;
    private int currentJump = 0;
    private Rigidbody rigidbody;
    private Vector3 velocity;


    
    private MovementMode movementMode;
    private character Character;
    private AnimationController animationController;
    
    private PlayerStats playerStats;
    private bool inAir;
    public delegate void OnLandedDelegate();

    public  event OnLandedDelegate onLanded;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rigidbody = GetComponent<Rigidbody>();
        setMovementMode(MovementMode.Walking);
        playerStats = GetComponent<PlayerStats>();
       
        powerUp = false;
    }

    // Update is called once per frame
    void Update()
    {
       

        //transform.Translate(velocity.normalized*maxSpeed);

        if (velocity.magnitude > 0)
        {
            rigidbody.velocity = new Vector3(velocity.normalized.x * SmoothSpeed, rigidbody.velocity.y, velocity.normalized.z * SmoothSpeed);
            SmoothSpeed = Mathf.Lerp(SmoothSpeed, maxSpeed, Time.deltaTime);
            //t_mesh.rotation = Quaternion.LookRotation(velocity);
            t_mesh.rotation = Quaternion.Lerp(t_mesh.rotation, Quaternion.LookRotation(velocity), Time.deltaTime * RotationSpeed);
        }
        else
        {
            SmoothSpeed = Mathf.Lerp(SmoothSpeed, 0, Time.deltaTime*4);
        }

        if (inAir)
        {
            if(Physics.Linecast(transform.position, transform.position + new Vector3(0, -9, 0)))
            {
                inAir = false;
                onLanded();
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(Dash());
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            maxSpeed = maxSpeed + SpeedBoost;
            WalkSpeed = WalkSpeed + SpeedBoost;
            RunSpeed = RunSpeed + SpeedBoost;
            SprintSpeed = SprintSpeed + SpeedBoost;
            powerUp = true;
            energybar.UseEnergy(10);
           
            StartCoroutine(SpeedBooster());
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            playerStats.healer(healing);
        }

       
    }
    
    

    internal void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) &&(OnGround||maxJump>currentJump))
        {
            rigidbody.AddForce(Vector3.up * jump_force);
            OnGround = false;
            inAir = true;
            currentJump++;
        }
       
    }

    

    

    IEnumerator Dash()
    {
        rigidbody.AddForce(Camera.main.transform.forward * dashForce, ForceMode.VelocityChange);
        if (energybar)
        {
            energybar.UseEnergy(10);
        }
        
        yield return new WaitForSeconds(dashDuration);
        rigidbody.velocity = Vector3.zero;
    }

    IEnumerator SpeedBooster()
    {
       
        yield return new WaitForSeconds(SpeedCd);
       
        maxSpeed = maxSpeed - SpeedBoost;
        WalkSpeed = WalkSpeed - SpeedBoost;
        RunSpeed = RunSpeed - SpeedBoost;
        SprintSpeed = SprintSpeed - SpeedBoost;
        powerUp = false;
    }
    

    public Vector3 Velocity { get => rigidbody.velocity; set => velocity = value; }

    public void setMovementMode(MovementMode mode)
    {
        movementMode = mode;
        switch (mode)
        {
            case MovementMode.Walking:
                {
                
                    maxSpeed = WalkSpeed; 
                   
                   
                      break;
                } 
            case MovementMode.Running:
                {
                    maxSpeed = RunSpeed;
                    
                    break;
                }

            case MovementMode.Sprinting:
                {
                    maxSpeed = SprintSpeed;
                    
                    
                    break;
                }
        }
    }

    public MovementMode GetMovementMode()
    {
        return movementMode;
    }

    void OnCollisionEnter(Collision collision)
    {
        OnGround = true;
        currentJump = 0;
        
    }
}
