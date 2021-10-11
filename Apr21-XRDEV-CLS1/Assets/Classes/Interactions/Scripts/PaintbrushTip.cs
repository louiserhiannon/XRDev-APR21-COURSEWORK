using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintbrushTip : MonoBehaviour
{
    public Material paint;
    public Material originalMaterial;

    void Start()
    {
        originalMaterial = GetComponent<Renderer>().material;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Paint")
        {
            paint = other.GetComponent<Renderer>().material;
            this.GetComponent<Renderer>().material = paint;
        }
    }
}
