using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapTurn : MonoBehaviour
{
    public Transform xRRig;
    public int angle;


    private VRInput controller;

    void Start()
    {
        controller = GetComponent<VRInput>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.thumbstick.x > 0.9f)
        {
            xRRig.transform.Rotate(0, angle, 0);
        }

        if (controller.thumbstick.x < -0.9f)
        {
            xRRig.transform.Rotate(0, -angle, 0);
        }
    }
}
