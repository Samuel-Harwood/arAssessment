using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class removeOnboarding : MonoBehaviour
{
    private ARPlaneManager arPlaneManager;
    public GameObject scanRoom;
    public GameObject tapToPlace;
    public GameObject apple;
    //public event Action<InteractableRegisteredEventArgs> interactableRegistered;

    public void Start()
    {
        // Get the ARPlaneManager component
        arPlaneManager = GetComponent<ARPlaneManager>();
        scanRoom.SetActive(true);
        tapToPlace.SetActive(false);

        // Enable plane detection
        if (arPlaneManager != null)
        {
            arPlaneManager.planesChanged += OnPlanesChanged;
        }

    }

    public void update()
    {
        if (!scanRoom.activeSelf && arPlaneManager.trackables.count < 1)
        {
            tapToPlace.SetActive(true);
            //arPlaneManager.planesChanged -= OnPlanesChanged;


        }
        if (arPlaneManager.trackables.count > 0)
        {

            tapToPlace.SetActive(false);

        }
    }
   
     

    private void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {

        if (args.added.Count > 0)
        {
            // Disable the specified game object
            scanRoom.SetActive(false);

        }
        //if (args.removed.Count > 0)
        //{
        //    // Disable the specified game object
        //    tapToPlace.SetActive(false);

        //}


    }
}