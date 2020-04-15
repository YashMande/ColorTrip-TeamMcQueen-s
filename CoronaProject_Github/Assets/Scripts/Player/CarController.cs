using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class CarController : MonoBehaviour
{

   

    [Header("WheelColliders")] //Wheel colliders attached to the wheels
    public WheelCollider WheelFL;
    public WheelCollider WheelFR;
    public WheelCollider WheelBL;
    public WheelCollider WheelBR;

    [Header("WheelGameObject")] //Wheel gameObject which has wheelcollider
    public GameObject FrontLeftWheel;
    public GameObject FrontRightWheel;
    public GameObject BackLeftWheel;
    public GameObject BackRightWheel;


    [Header("Variables")]
    public float topSpeed; //max speed 
    public float maxTroque; // how much torque to apply to the wheels
    public float maxSteerAngle; // steering value
    public float currentSpeed; //gets current speed
    public float maxBrakeTorque; //brake force


    
    private float Forward; //Vertical axis
    private float Turn; // Horiazontal axis
    private float Brake; 

    Rigidbody rb;

    CollisionDetection cD;
    public GameObject groundDetection;
    public bool switchPosition;
    public float timer = 3;
    


    void Start()
    {
        
        rb = gameObject.GetComponent<Rigidbody>();
        cD = groundDetection.GetComponent<CollisionDetection>();
    }

  
    void FixedUpdate()
    {

        Forward = Input.GetAxis("Vertical");
        Turn = Input.GetAxis("Horizontal");
        Brake = Input.GetAxis("Jump");

        WheelFL.steerAngle = maxSteerAngle * Turn; // Steering 
        WheelFR.steerAngle = maxSteerAngle * Turn;


        if (currentSpeed < topSpeed)
        {
            WheelBL.motorTorque = maxTroque * Forward * 3; //Run the wheels 
            WheelBR.motorTorque = maxTroque * Forward * 3;
            WheelFR.motorTorque = maxTroque * Forward * 3;
            WheelFL.motorTorque = maxTroque * Forward * 3;

        }

        WheelBL.brakeTorque = maxTroque * Brake; //Brake force applied to the wheels
        WheelBR.brakeTorque = maxTroque * Brake;
        WheelFL.brakeTorque = maxTroque * Brake;
        WheelFR.brakeTorque = maxTroque * Brake;
        if (gameObject.tag == "RedCar")
        {
            if (cD.redLane == true || cD.whiteLane == true)
            {
                Debug.Log("CorrectLane");
                currentSpeed = 3 * 22 / 7 * WheelBL.radius * WheelBL.rpm * 60 / 1000; //Formula for speed in kmph
                timer = 3;
               
            }
            else
            {
                Debug.Log("WrongLane");
                currentSpeed = 3 * 22 / 7 * WheelBL.radius * WheelBL.rpm * 60 / 1000; //Formula for speed in kmph
                WheelBL.brakeTorque = maxTroque * 4; //Brake force applied to the wheels
                WheelBR.brakeTorque = maxTroque * 4;
                WheelFL.brakeTorque = maxTroque * 4;
                WheelFR.brakeTorque = maxTroque * 4;
                timer = timer - 1f * Time.deltaTime;
               
               
             
            }
        }


    }

     void Update()
    {
        
        if(timer <= 0)
        {
            timer = 0;

        }
        

        Quaternion frontLeftR; //rotation of wheel collider
        Vector3 frontLeftP; // position of wheel collider
        WheelFL.GetWorldPose(out frontLeftP, out frontLeftR); // gets wheel colliders posiiton and rotation
        FrontLeftWheel.transform.position = frontLeftP;
        FrontLeftWheel.transform.rotation = frontLeftR;

        Quaternion frontRightR;
        Vector3 frontRightP;
        WheelFR.GetWorldPose(out frontRightP, out frontRightR);
        FrontRightWheel.transform.position = frontRightP;
        FrontRightWheel.transform.rotation = frontRightR;

        Quaternion backLeftR;
        Vector3 backLeftP; ;
        WheelBL.GetWorldPose(out backLeftP, out backLeftR);
        BackLeftWheel.transform.position = backLeftP;
        BackLeftWheel.transform.rotation = backLeftR;

        Quaternion backRightR;
        Vector3 backRightP;
        WheelBR.GetWorldPose(out backRightP, out backRightR);
        BackRightWheel.transform.position = backRightP;
        BackRightWheel.transform.rotation = backRightR;

        if (currentSpeed <= 0)
        {
            currentSpeed = 0;
        }


    }

   


}

