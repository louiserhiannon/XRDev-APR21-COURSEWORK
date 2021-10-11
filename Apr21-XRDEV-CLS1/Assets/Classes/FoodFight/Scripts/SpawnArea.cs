using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    public Target targetPrefab;
    public Collider spawnAreaCollider;

    void Start()
    {
        SpawnTarget();
    }

    public void SpawnTarget()
    {
        var spawnedTarget = Instantiate(targetPrefab, RandomTargetPosition(), targetPrefab.transform.rotation);
        
        spawnedTarget.spawnArea = this; //assigning 'spawnedTarget' to target game object that carries Target script

    }

    private Vector3 RandomTargetPosition()
    {
        float xValue = Random.Range(spawnAreaCollider.bounds.min.x, spawnAreaCollider.bounds.max.x);
        float yValue = Random.Range(spawnAreaCollider.bounds.min.y, spawnAreaCollider.bounds.max.y);
        float zValue = Random.Range(spawnAreaCollider.bounds.min.z, spawnAreaCollider.bounds.max.z);

        //because the method type returns a vector 3, must have a 'return' statement of the corresponding types
        return new Vector3(xValue, yValue, zValue);
    }
}
