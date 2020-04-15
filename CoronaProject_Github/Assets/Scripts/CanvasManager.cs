using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasManager : MonoBehaviour
{
    public Text currentSpeedT;
    public int currentSpeed;
    CarController carCon;

    void Start()
    {
        carCon = GetComponentInParent<CarController>();
    }


    void Update()
    {

        currentSpeed = Mathf.RoundToInt(carCon.currentSpeed);
        currentSpeedT.text = currentSpeed.ToString();
    }
}
