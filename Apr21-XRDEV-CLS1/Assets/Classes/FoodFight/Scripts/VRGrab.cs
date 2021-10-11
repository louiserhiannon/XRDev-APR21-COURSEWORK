using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRGrab : MonoBehaviour
{
    private VRInput controller;
    public GrabbableObject hoveredObject;
    public GrabbableObject grabbedObject;

    public float throwForce;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<VRInput>();
        controller.OnGripDown.AddListener(ADVGrab); // hooks into event identified in VRInput and connects it to ADVGrab()
        controller.OnGripUp.AddListener(ADVRelease); // hooks into event identified in VRInput and connects it to ADVRelease()
    }

    private void OnDisable()
    {
        controller.OnGripDown.RemoveListener(ADVGrab);
        controller.OnGripUp.RemoveListener(ADVRelease);
    }

    private void OnTriggerEnter(Collider other)
    {
        var grabbable = other.GetComponent<GrabbableObject>();
        if (grabbable != null)
        {
            hoveredObject = grabbable;
            hoveredObject.OnHoverStart();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var grabbable = other.GetComponent<GrabbableObject>();
        if (grabbable == hoveredObject)
        {
            hoveredObject.OnHoverEnd(); 
            hoveredObject = null;
        }
    }

    public void Grab()
    {
        //check to see if there is a grabbable object
        //if it is, grab it
        if(hoveredObject != null)
        {
            grabbedObject = hoveredObject;
            grabbedObject.OnGrab(controller);
            //note that you can use the same method name in multiple contexts as long as they take different parameters
            //adding interations

            
            //set the trigger button to call interaction methods (the specifics of which depend on the applicable override voids)
            controller.OnTriggerDown.AddListener(grabbedObject.OnInteraction);
            controller.OnTriggerUpdated.AddListener(grabbedObject.OnUpdatingInteraction);
            controller.OnTriggerUp.AddListener(grabbedObject.OnStopInteraction);

        }

    }

    public void Release()
    {
        //check to see if there is a grabbed object
        //if it is, release it
        if (grabbedObject != null)
        {
            grabbedObject.OnRelease(controller);
            //note that you can use the same method name in multiple contexts as long as they take different parameters

            //Remove Interactions
            controller.OnTriggerDown.RemoveListener(grabbedObject.OnInteraction);
            controller.OnTriggerUpdated.RemoveListener(grabbedObject.OnUpdatingInteraction);
            controller.OnTriggerUp.RemoveListener(grabbedObject.OnStopInteraction);

            //throw
            grabbedObject.rigidBody.velocity = controller.velocity * throwForce;
            grabbedObject.rigidBody.angularVelocity = controller.angularVelocity * throwForce;

            grabbedObject = null;
        }
    }

    public void ADVGrab()
    {
        if (hoveredObject != null)
        {
            grabbedObject = hoveredObject;
            grabbedObject.OnADVGrab(controller);

            //set the trigger button to call interaction methods (the specifics of which depend on the applicable override voids)
            controller.OnTriggerDown.AddListener(grabbedObject.OnInteraction);
            controller.OnTriggerUpdated.AddListener(grabbedObject.OnUpdatingInteraction);
            controller.OnTriggerUp.AddListener(grabbedObject.OnStopInteraction);
        }
    }

    public void ADVRelease()
    {
        if (grabbedObject != null)
        {
            grabbedObject.OnADVRelease(controller);

            //Remove Interactions
            controller.OnTriggerDown.RemoveListener(grabbedObject.OnInteraction);
            controller.OnTriggerUpdated.RemoveListener(grabbedObject.OnUpdatingInteraction);
            controller.OnTriggerUp.RemoveListener(grabbedObject.OnStopInteraction);

            //throw
            grabbedObject.rigidBody.velocity = controller.velocity * throwForce;
            grabbedObject.rigidBody.angularVelocity = controller.angularVelocity * throwForce;

            grabbedObject = null;
        }
    }
}
