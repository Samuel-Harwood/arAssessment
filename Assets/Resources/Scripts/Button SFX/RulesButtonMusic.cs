using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulesButtonMusic : MonoBehaviour
{
    private static RulesButtonMusic instance;

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Don't destroy this GameObject when loading a new scene

        }
    }
}
