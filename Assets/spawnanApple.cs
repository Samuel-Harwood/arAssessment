using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class spawnanApple : MonoBehaviour
{
    private CompletelySad cameraray;
    public GameObject objectToPlace;
    private GameObject newPlacedObject;
 
    void Start()
    {
        cameraray = FindObjectOfType<CompletelySad>();
        Debug.Log(cameraray);
    }

    public void ClickToPlace()
    {
        ARSession arSession = FindObjectOfType<ARSession>();

        newPlacedObject = Instantiate(objectToPlace, arSession.transform.position, cameraray.transform.rotation, arSession.transform);

        //newPlacedObject = Instantiate(objectToPlace, cameraray.transform.position, cameraray.transform.rotation);
    }


}
