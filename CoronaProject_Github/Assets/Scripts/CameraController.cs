using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;
    public Transform looktarget;
    public float snapSpeed;
    public Vector3 distance;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dPos = target.position + distance;
        Vector3 sPos = Vector3.Lerp(transform.position, dPos, snapSpeed * Time.deltaTime);
        transform.position = sPos;
        transform.LookAt(looktarget.position);
    }
}
