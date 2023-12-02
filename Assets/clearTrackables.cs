using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class clearTrackables : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;

    public void ahoySpongebob()
    {
        Destroy(trackedImageManager);

    }
}
