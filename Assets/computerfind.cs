using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class computerfind : MonoBehaviour
{

    void Start()
    {
        GameObject[] spawn = GameObject.FindGameObjectsWithTag("spawn");
        foreach (GameObject spawnObject in spawn)
        {
            spawnObject.SetActive(false);
            Destroy(spawnObject);
        }
        SpawnChildObject();
    }
    public GameObject childPrefab;

  

    void SpawnChildObject()
    {
        // Spawn a child object
        GameObject spawnedChild = Instantiate(childPrefab, transform.position + Vector3.up, Quaternion.identity);

        // Optionally, you can set the spawned child as a child of the current object
        spawnedChild.transform.parent = transform;
    }

}

