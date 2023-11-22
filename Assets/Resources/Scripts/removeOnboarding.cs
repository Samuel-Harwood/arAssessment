using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class removeOnboarding : MonoBehaviour
{
    private ARPlaneManager arPlaneManager;

    public GameObject scanRoom;
    public GameObject tapToPlace;

    public void Start()
    {
        // Get the ARPlaneManager component
        arPlaneManager = GetComponent<ARPlaneManager>();
;
        scanRoom.SetActive(true);
        tapToPlace.SetActive(false);
        // Enable plane detection
        if (arPlaneManager != null)
        {
            arPlaneManager.planesChanged += OnPlanesChanged;
        }

    }

    public void FixedUpdate()
    {

        //tapToPlace.SetActive(!tapToPlace.activeSelf);

        if (!scanRoom.activeSelf) 
        {
            tapToPlace.SetActive(true);
        }

    }
   
     

    private void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {

        if (args.added.Count > 0)
        {
            // Disable the specified game object
            scanRoom.SetActive(false);

        }



    }
}