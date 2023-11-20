using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMusicManager : MonoBehaviour
{
    private static ButtonMusicManager instance;

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Don't destroy this GameObject when loading a new scene

        }
    }



    // Add any additional functionality you need, such as controlling music volume, etc.

    // Example method to stop the music

    // Add any additional functionality you need, such as controlling music volume, etc.
}
