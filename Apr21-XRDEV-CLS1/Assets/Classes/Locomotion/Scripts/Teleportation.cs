using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{

    public Transform xRRig;
    private VRInput controller;
    private LineRenderer line;
    public GameObject teleportReticle;
    private Vector3 hitPosition;
    private Vector3 hitNormal;
    private bool shouldTeleport = false;
    [Range(5, 50)] public int lineResolution; //range makes a little slider
    public float midPointHeight;
    public float smoothingFactor = 2;
    private Vector3 smoothedEndPosition;

    void Start()
    {
        controller = GetComponent<VRInput>();
        line = GetComponent<LineRenderer>();
        line.enabled = false;
        line.positionCount = lineResolution + 1;
        teleportReticle.SetActive(false);


        controller.OnThumbstickUpdated.AddListener(RaycastTeleport); // hooks into event identified in VRInput and connects it to Raycast Teleport()
        controller.OnThumbstickUp.AddListener(Teleport); // hooks into event identified in VRInput and connects it to Teleport()

    }

    public void RaycastTeleport()
    {
        RaycastHit hit; //specific unity data type
        if(Physics.Raycast(transform.position, transform.forward, out hit))
        {
            //Smooth the jitter
            Vector3 desiredPosition = hit.point;
            Vector3 directionToDesiredPoint = (desiredPosition - hitPosition) / smoothingFactor;
            smoothedEndPosition = hitPosition + directionToDesiredPoint;
            
            CurveLine(smoothedEndPosition);

            hitPosition = smoothedEndPosition;
            hitNormal = hit.normal;
            //line.SetPosition(0, transform.position);
            //line.SetPosition(1, hitPosition);

            teleportReticle.transform.position = hitPosition;
            teleportReticle.transform.LookAt(hitNormal + hitPosition);
            teleportReticle.SetActive(true);
            line.enabled = true;
            shouldTeleport = true;
        }
    }
    public void Teleport()
    {
        if(shouldTeleport == true)
        {
            xRRig.position = hitPosition;

            // visuals
            line.enabled = false;
            shouldTeleport = false;
            teleportReticle.SetActive(false);
        }
    }

    private void CurveLine(Vector3 hitPoint)
    {
        Vector3 startPosition = controller.transform.position;
        Vector3 endPosition = hitPoint;
        Vector3 midPosition = startPosition + (endPosition - startPosition) / 2;

        midPosition.y += midPointHeight;

        for (int i = 0; i <= lineResolution; i++)
        {

            float t = (float)i / (float)lineResolution;
            Vector3 startToMid = Vector3.Lerp(startPosition, midPosition, t);
            Vector3 midToEnd = Vector3.Lerp(midPosition, endPosition, t);
            Vector3 curvePosition = Vector3.Lerp(startToMid, midToEnd, t);

            line.SetPosition(i, curvePosition);
        }
    }
}
