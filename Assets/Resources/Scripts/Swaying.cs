using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swaying : MonoBehaviour
{
    public float swayAmount = 1.0f;  // Adjust the amount of sway
    public float swaySpeed = 1.0f;   // Adjust the speed of the sway
    private float initialX = 36;  // Added variable to store initial X position

    private void Start()
    {
        initialX = transform.position.x;

    }

    private void Update()
    {
        // Calculate the sway based on time
        float sway = Mathf.Sin(Time.time * swaySpeed) * swayAmount;

        // Apply the sway to the object's position
        transform.position = new Vector3(initialX + sway, transform.position.y, transform.position.z);
    }
}
