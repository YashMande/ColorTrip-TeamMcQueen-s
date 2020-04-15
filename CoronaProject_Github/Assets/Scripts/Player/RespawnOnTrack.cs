using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnOnTrack : MonoBehaviour
{

    public bool rsRed;
    public bool rsBlue;
    public bool rsYellow;
    public bool rsGreen;
    public GameObject player;

    public Vector3 redTrack;
    CarController Cc;
    // Start is called before the first frame update
    void Start()
    {
       
        Cc = gameObject.GetComponentInParent<CarController>();
    }

    // Update is called once per frame
    void Update()
    {


        if (player.tag == "RedCar")
        {
            if (Cc.timer == 0)
            {
                player.transform.position = new Vector3(redTrack.x, player.transform.position.y, redTrack.z);
                
            }
            else
            {
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
            }
        }
                
         
           
        
        
    }
   


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RedLane")
        {
            rsRed = true;
            redTrack = other.gameObject.transform.position;
        }
        if (other.gameObject.tag == "BlueLane")
        {
            rsBlue = true;
        }
        if (other.gameObject.tag == "YellowLane")
        {
            rsYellow = true;
        }
        if (other.gameObject.tag == "GreenLane")
        {
            rsGreen = true;
        }
        if (other.gameObject.tag == "WhiteLane")
        {
          //  whiteLane = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "RedLane")
        {
            rsRed = false;
            redTrack = other.gameObject.transform.position;
        }
        if (other.gameObject.tag == "BlueLane")
        {
            rsBlue = false;
        }
        if (other.gameObject.tag == "YellowLane")
        {
            rsYellow = false;
        }
        if (other.gameObject.tag == "GreenLane")
        {
            rsGreen = false;
        }
        if (other.gameObject.tag == "WhiteLane")
        {
            //  whiteLane = true;
        }
    }
}
