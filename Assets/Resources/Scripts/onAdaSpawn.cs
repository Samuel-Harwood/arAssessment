using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onAdaSpawn : MonoBehaviour
{
    void Start()
    {
        GameObject[] spawn1 = GameObject.FindGameObjectsWithTag("spawn1");
        foreach (GameObject spawnObject in spawn1)
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
        //StartCoroutine(startTime());

    }



    //IEnumerator startTime()
    //{
    //    Debug.Log("Start wait");
    //    yield return new WaitForSeconds(3f);
    //    GameObject[] ada = GameObject.FindGameObjectsWithTag("ada");
    //    foreach (GameObject ad in ada)
    //    {
    //        ad.SetActive(true);
    //    }

    //    Debug.Log("End wait");
    //    // Do something else
    //}
}
 