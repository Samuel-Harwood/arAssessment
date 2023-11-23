using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shrinking : MonoBehaviour
{
    public float shrinkSpeed = 2f; // Adjust the speed as needed

    void FixedUpdate()
    {
        // Shrink the object gradually
        Shrink();
    }

    void Shrink()
    {
        // Calculate the new scale based on time and shrink speed
        float newScale = transform.localScale.x - (shrinkSpeed * Time.deltaTime);

        // Make sure the new scale is not less than or equal to zero
        newScale = Mathf.Max(newScale, 0f);

        // Apply the new scale to all axes (assuming uniform scaling)
        transform.localScale = new Vector3(newScale, newScale, newScale);

        // If the object has shrunk to a very small size, you can optionally destroy it
        if (newScale <= 0.001f)
        {
            // Destroy the GameObject or deactivate it as needed
            Destroy(gameObject);
        }
    }
}
