using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class removeOnboarding : MonoBehaviour
{
    private ARPlaneManager arPlaneManager;

    public GameObject onboarding1;
    public GameObject onboarding2;
    private bool onboardingDisplayed = false;
    public void Start()
    {
        // Get the ARPlaneManager component
        arPlaneManager = GetComponent<ARPlaneManager>();

        //scanRoom.SetActive(true);
        //tapToPlace.SetActive(false);
        // Enable plane detection
        if (arPlaneManager != null)
        {
            arPlaneManager.planesChanged += OnPlanesChanged;
        }

    }



    private void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
   
        if (!onboardingDisplayed && args.added.Count > 0)
        {

            ToggleOnboardingSets();

            // Set onboardingDisplayed to true once onboarding is displayed
            onboardingDisplayed = true;
        }



    }

    private void ToggleOnboardingSets()
    {
        // Toggle between sets of onboarding messages
        onboarding1.SetActive(!onboarding1.activeSelf);
        onboarding2.SetActive(!onboarding2.activeSelf);
    }
}

