using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float moveSpeed;
    public float distance;
    public SpawnArea spawnArea;

    private float startingPosition;

       
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position; //or Var
        currentPosition.x = startingPosition + Mathf.Sin(Time.time * moveSpeed) * distance;
        transform.position = currentPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //set food as collider (setting it to a grabbable object ensures that it is something that has been thrown by us)
        var food = collision.collider.GetComponent<GrabbableObject>();
        //check if there is a collision
        if(food != null)
        {
            //destroy food
            Destroy(food.gameObject);
            //destroy target
            Destroy(this.gameObject);
            //spawn new target
            spawnArea.SpawnTarget();
        }
    }
}
