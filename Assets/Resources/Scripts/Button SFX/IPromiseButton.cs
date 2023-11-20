using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPromiseButton : MonoBehaviour
{
    private static IPromiseButton instance;

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Don't destroy this GameObject when loading a new scene

        }
    }
}
