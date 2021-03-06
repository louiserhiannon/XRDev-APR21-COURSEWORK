using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    private Vector3 axisOfRotation;
    public float rotationSpeed;
    

    void Start()
    {
        //Set axis of rotation as the y axis
        axisOfRotation = new Vector3(0f, 1f, 0f);
    }

       
    void Update()
    {
        //Rotate planet around LOCAL coordinates at rotation speed
        transform.Rotate(axisOfRotation * rotationSpeed * Time.deltaTime, Space.Self);

    }
}
