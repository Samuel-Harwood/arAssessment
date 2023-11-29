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



        GameObject[] treasure = GameObject.FindGameObjectsWithTag("treasure");
        if (treasure.Length == 0)
        {
            Debug.LogWarning("No game objects found with tag 'treasure'.");
        }
        foreach (GameObject tre in treasure)
        {
            tre.SetActive(true);
        }

    }


}
