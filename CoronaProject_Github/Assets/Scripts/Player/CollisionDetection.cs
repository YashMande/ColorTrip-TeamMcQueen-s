using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public bool redLane;
    public bool blueLane;
    public bool greenLane;
    public bool yellowLane;
    public bool whiteLane;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "RedLane")
        {
            redLane = true;
        }
        if (other.gameObject.tag == "BlueLane")
        {
            blueLane = true;
        }
        if (other.gameObject.tag == "YellowLane")
        {
            yellowLane = true;
        }
        if (other.gameObject.tag == "GreenLane")
        {
            greenLane = true;
        }
        if (other.gameObject.tag == "WhiteLane")
        {
            whiteLane = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "RedLane")
        {
            redLane = false;
        }
        if (other.gameObject.tag == "BlueLane")
        {
            blueLane = false;
        }
        if (other.gameObject.tag == "YellowLane")
        {
            yellowLane = false;
        }
        if (other.gameObject.tag == "GreenLane")
        {
            greenLane = false;
        }
        if (other.gameObject.tag == "WhiteLane")
        {
            whiteLane = false;
        }
    }
}
