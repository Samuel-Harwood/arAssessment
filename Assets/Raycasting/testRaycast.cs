using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class testRaycast : MonoBehaviour
{

    //Ray ray;

    //void Update()
    //{
    //    Debug.Log("Update!");
    //    float sphereRadius = 1.0f;
    //    Collider[] colliders = Physics.OverlapSphere(transform.position, sphereRadius);

    //    foreach (Collider collider in colliders)
    //    {
    //        // Perform a raycast from the center of the sphere to each collider
    //        Ray ray = new Ray(transform.position, (collider.transform.position - transform.position).normalized);

    //        RaycastHit hit;
    //        if (Physics.Raycast(ray, out hit))
    //        {
    //            Debug.Log(hit.collider.gameObject.name + " was hit!");
    //            Destroy(hit.collider.gameObject);
    //        }
    //    }
    //}
    private Renderer renderer;


    private void Update()
    {
        var ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        renderer = GetComponent<Renderer>();

        if (Physics.Raycast(ray, out hit, 100000f))
        {
            if (hit.collider.tag.Equals("knight"))
            {
                renderer.material.color = Color.green;
                Debug.Log(hit.collider.gameObject.name + " was hit!");
                Destroy(hit.collider.gameObject);
            }
            else
            {
                Debug.Log(hit.collider.gameObject.name + " was hit!");
            }
        }
        else
        {
            Debug.Log("Update");
        }
    }



}
