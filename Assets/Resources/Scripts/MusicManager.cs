using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Don't destroy this GameObject when loading a new scene
            SceneManager.activeSceneChanged += OnActiveSceneChanged; // Subscribe to the activeSceneChanged event

        }
        else
        {
            Destroy(gameObject); // If an instance already exists, destroy this GameObject
        }
    }

    void OnActiveSceneChanged(Scene previousScene, Scene newScene)
    {
        Debug.Log("Scene Changed: " + newScene.name);

        // Check if the current scene is not TitleScreen or RulesScreen, then stop the music
        if (newScene.name != "TitleScreen" && newScene.name != "RulesScreen")
        {
            StopMusic();
        }
    }

    // Add any additional functionality you need, such as controlling music volume, etc.

    // Example method to stop the music
    public void StopMusic()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }
    // Add any additional functionality you need, such as controlling music volume, etc.
}
