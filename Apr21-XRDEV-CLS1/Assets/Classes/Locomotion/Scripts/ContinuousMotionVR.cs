using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousMotionVR : MonoBehaviour
{
    public Transform xRRig;
    public Transform director; //whatever is controlling direction - could be controller or head

    private VRInput controller;
    private Vector3 forwardDirection;
    private Vector3 rightDirection;
    
    void Start()
    {
        controller = GetComponent<VRInput>();
    }

    
    void Update()
    {
        //get direction of controller
        forwardDirection = director.forward;
        //stop it going up...
       forwardDirection.y = 0f;
       forwardDirection.Normalize();

        rightDirection = director.right;
        rightDirection.y = 0f;
        rightDirection.Normalize();

        // move rig in direction of controller at speed from controller
        xRRig.position += forwardDirection * controller.thumbstick.y * Time.deltaTime;
        xRRig.position += rightDirection * controller.thumbstick.x * Time.deltaTime;
    }
}
