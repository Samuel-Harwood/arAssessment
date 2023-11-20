using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonSFX : MonoBehaviour
{
    private static StartButtonSFX instance;

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Don't destroy this GameObject when loading a new scene

        }
    }
}
