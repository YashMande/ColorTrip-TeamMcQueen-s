using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[RequireComponent(typeof(InputManager))]

public class CarController : MonoBehaviour
{

    /* public InputManager iM;
     public List<WheelCollider> throttleWheels;
     public List<WheelCollider> steerWheels;

     public float maxTurn;
     public float strenghtCoeifficient;*/


    public WheelCollider WheelFL;
    public WheelCollider WheelFR;
    public WheelCollider WheelBL;
    public WheelCollider WheelBR;


    public GameObject FrontLeftWheel;
    public GameObject FrontRightWheel;
    public GameObject BackLeftWheel;
    public GameObject BackRightWheel;

    public float topSpeed;
    public float maxTroque;
    public float maxSteerAngle;
    public float currentSpeed;
    public float maxBrakeTorque;


    private float Forward;
    private float Turn;
    private float Brake;

    Rigidbody rb;


    void Start()
    {
        //iM = gameObject.GetComponent<InputManager>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

  
    void FixedUpdate()
    {
        /* foreach (WheelCollider wheel in throttleWheels)
         {
             wheel.motorTorque = strenghtCoeifficient * Time.deltaTime  * iM.throttle;
         }
         foreach (WheelCollider wheel in steerWheels)
         {
             wheel.steerAngle = maxTurn * iM.steer ;
         }*/


        Forward = Input.GetAxis("Vertical");
        Turn = Input.GetAxis("Horizontal");
        Brake = Input.GetAxis("Jump");

        WheelFL.steerAngle = maxSteerAngle * Turn;
        WheelFR.steerAngle = maxSteerAngle * Turn;

        currentSpeed = 3 * 22 / 7 * WheelBL.radius * WheelBL.rpm * 60 / 1000;

        if(currentSpeed < topSpeed)
        {
            WheelBL.motorTorque = maxTroque * Forward * 3;
            WheelBR.motorTorque = maxTroque * Forward * 3;
            WheelFR.motorTorque = maxTroque * Forward * 3;
            WheelFL.motorTorque = maxTroque * Forward * 3;

        }

        WheelBL.brakeTorque = maxTroque * Brake;
        WheelBR.brakeTorque = maxTroque * Brake;
        WheelFL.brakeTorque = maxTroque * Brake;
        WheelFR.brakeTorque = maxTroque * Brake;


    }

     void Update()
    {
        //gameObject.transform.rotation = new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y, 0, gameObject.transform.rotation.w);
        Quaternion frontLeftR;
        Vector3 frontLeftP;
        WheelFL.GetWorldPose(out frontLeftP, out frontLeftR);
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

    }
}

