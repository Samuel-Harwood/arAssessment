using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChild : MonoBehaviour
{
    public GameObject childPrefab;

    void Start()
    {
        SpawnChildObject();
    }

    void SpawnChildObject()
    {
        // Spawn a child object
        GameObject spawnedChild = Instantiate(childPrefab, transform.position + Vector3.up, Quaternion.identity);

        // Optionally, you can set the spawned child as a child of the current object
        spawnedChild.transform.parent = transform;
    }
}
