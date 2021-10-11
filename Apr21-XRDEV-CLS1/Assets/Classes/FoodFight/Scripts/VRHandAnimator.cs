using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRHandAnimator : MonoBehaviour
{
    private VRInput controller;
    private Animator handAnimator;

    void Start()
    {
        controller = GetComponent<VRInput>();
        handAnimator = GetComponentInChildren<Animator>(); //component is on child of object attached to script
    }

    
    void Update()
    {
        if (controller)
        {
            handAnimator.Play("Fist Closing", 0, controller.gripValue);
        }
    }
}
