using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onSpawn : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        //GameObject[] treasure = GameObject.FindGameObjectsWithTag("treasure");

        //foreach (GameObject tre in treasure)
        //{
        //    tre.SetActive(true);
        //}


        GameObject[] spawn = GameObject.FindGameObjectsWithTag("spawn");
        foreach (GameObject spawnObject in spawn)
        {
            spawnObject.SetActive(false);
            Destroy(spawnObject);
        }
    }

    
}
