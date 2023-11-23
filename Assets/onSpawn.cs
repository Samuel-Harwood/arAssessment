using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] spawn = GameObject.FindGameObjectsWithTag("spawn");

        foreach (GameObject spawnObject in spawn)
        {
            spawnObject.SetActive(false);
            Destroy(spawnObject);
        }
    }

    
}
