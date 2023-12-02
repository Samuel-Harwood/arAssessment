using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableButtonOnRaycast : MonoBehaviour
{
    public LayerMask raycastLayer;

    private void Start()
    {
  
       
    }

    public void killApple()
    {
        GameObject[] apple = GameObject.FindGameObjectsWithTag("apple");

        foreach (GameObject app in apple)
        {
            app.SetActive(false);
        }
        GameObject[] knight = GameObject.FindGameObjectsWithTag("completelyNew");

        foreach (GameObject kn in knight)
        {
            kn.SetActive(false);
        }
    }

    private void Update()
    {
        // Perform a raycast to check if the button is hit
        // Define the starting point and direction of the raycast
        Vector2 raycastOrigin = transform.position;
        Vector2 raycastDirection = Vector2.up; // You can change this direction as needed

        // Perform the raycast
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, raycastDirection, Mathf.Infinity, raycastLayer);

        // Check if the raycast hit something
        if (hit.collider != null)
        {
            Debug.Log("Image is blocking the raycast!");

            // Check if the hit object is the image
            if (hit.collider.gameObject == gameObject)
            {
                // The image is blocking the raycast
                Debug.Log("Image is blocking the raycast!");
            }
        }

    }

}