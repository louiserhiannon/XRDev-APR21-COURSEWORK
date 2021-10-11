using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paintbrush : GrabbableObject
{
    public GameObject paintPrefab;
    public GameObject spawnedPrefab;
    private PaintbrushTip paintbrushTip;
    void Start()
    {
        paintbrushTip = GetComponentInChildren<PaintbrushTip>();
    }

    public override void OnInteraction() 
    {
        spawnedPrefab = Instantiate(paintPrefab, paintbrushTip.transform.position, paintbrushTip.transform.rotation);
        TrailRenderer paintTrail = spawnedPrefab.GetComponent<TrailRenderer>();
        paintTrail.GetComponent<Renderer>().material = paintbrushTip.paint;
    }

    public override void OnUpdatingInteraction()
    {
        if (spawnedPrefab)
        {
            spawnedPrefab.transform.position = paintbrushTip.transform.position;
        }
    }

    public override void OnStopInteraction()
    {
        spawnedPrefab.transform.position = spawnedPrefab.transform.position;
        spawnedPrefab = null;
    }

}
