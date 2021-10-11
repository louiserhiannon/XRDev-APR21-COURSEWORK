using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    public Color hoverColour;
    public Color nonHoverColour;
    public Rigidbody rigidBody; //expose rigidbody so it can be seenby VRGrab

    private Material objectMaterial;

    private void Start()
    {
        objectMaterial = GetComponent<Renderer>().material; //material is an element on the Renderer component
        rigidBody = GetComponent<Rigidbody>();
    }


    public virtual void OnInteraction() //look up virtual voids
    {

    }

    public virtual void OnUpdatingInteraction()
    {

    }

    public virtual void OnStopInteraction()
    {

    }

    public void OnHoverStart()
    {
        objectMaterial.color = hoverColour;
    }

    public void OnHoverEnd()
    {
        objectMaterial.color = nonHoverColour;
    }

    public void OnGrab(VRInput hand)
    {
        Debug.Log("Grab!");
        //set parent body to be hand
        transform.SetParent(hand.transform);

        //set rigidbody to be kinematic (not impacted by gravity)
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;

    }

    public void OnRelease(VRInput hand)
    {
        Debug.Log("Release!");
        //Remove object from hand parent
        transform.SetParent(null);

        //set rigidbody to use Gravity (not Is Kinematic)
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().useGravity = true;
    }

    public void OnADVGrab(VRInput hand)
    {
        FixedJoint fx = hand.gameObject.AddComponent<FixedJoint>();
        fx.connectedBody = rigidBody;
    }

    public void OnADVRelease(VRInput hand)
    {
        FixedJoint fx = hand.GetComponent<FixedJoint>();
        Destroy(fx);
    }
}
