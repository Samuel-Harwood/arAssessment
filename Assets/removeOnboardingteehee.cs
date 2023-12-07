using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeOnboardingteehee : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

        GameObject[] spawn2 = GameObject.FindGameObjectsWithTag("spawn1");
        foreach (GameObject spawnObject in spawn2)
        {
            spawnObject.SetActive(false);
            Destroy(spawnObject);
        }
    }


}
