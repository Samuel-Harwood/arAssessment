using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class removeOnboarding : MonoBehaviour
{
    private ARPlaneManager arPlaneManager;
    public GameObject removeCanvas;

    private void OnEnable()
    {
        // Get the ARPlaneManager component
        arPlaneManager = GetComponent<ARPlaneManager>();

        // Enable plane detection
        if (arPlaneManager != null)
        {
            arPlaneManager.planesChanged += OnPlanesChanged;
        }
    }


    private void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        if (args.added.Count > 0)
        {
            // Disable the specified game object
            if (removeCanvas != null)
            {
                removeCanvas.SetActive(false);
            }
        }
    }

}