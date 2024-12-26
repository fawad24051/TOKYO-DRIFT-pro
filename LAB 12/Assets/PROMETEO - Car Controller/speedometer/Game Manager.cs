using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PrometeoCarController RR;
    public GameObject needle;
    private float startPosition=220f, endPosition=-41;
    private float desiredPosition;

    public float vehicleSpeed;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        vehicleSpeed = RR.carSpeed;
        updateNeedle();
    }
    public void updateNeedle()
    {
        desiredPosition= startPosition - endPosition;
        float temp = vehicleSpeed / 180;
        needle.transform.eulerAngles = new Vector3(0, 0, (startPosition - desiredPosition * temp));

    }
}
