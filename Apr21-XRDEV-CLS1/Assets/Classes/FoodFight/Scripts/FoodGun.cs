using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGun : GrabbableObject //notice that GrabbableObject is listed instead of monobehaviour
{

    public List<GameObject> foodPrefabs = new List<GameObject>();
    public Transform spawnPoint;
    public float shootingForce = 1000f;
    public int foodIndex = 0;

    public override void OnInteraction()
    {
        GameObject food = Instantiate(foodPrefabs[foodIndex], spawnPoint.position, spawnPoint.rotation);
        Rigidbody foodRigidBody = food.GetComponent<Rigidbody>();
        foodRigidBody.AddForce(food.transform.forward * shootingForce);

        foodIndex = Random.Range(0, foodPrefabs.Count);

    }

    
}
