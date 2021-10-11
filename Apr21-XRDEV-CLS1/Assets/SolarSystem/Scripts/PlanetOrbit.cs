using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetOrbit : MonoBehaviour
{

    public Transform orbitedBody;
    public float orbitDistance;
    public float orbitalSpeed; //Degrees per secon
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Set or update position of orbiting body relative to orbited body
        transform.position = orbitedBody.position + (transform.position - orbitedBody.position).normalized * orbitDistance;

        //Rotate around target's y-axis at specified speed
        transform.RotateAround(orbitedBody.position, Vector3.up, orbitalSpeed * Time.deltaTime);

    }
}
