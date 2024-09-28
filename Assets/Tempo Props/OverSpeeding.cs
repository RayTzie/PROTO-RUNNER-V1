using UnityEngine;
using UnityEngine.UI;

public class OverSpeeding : MonoBehaviour
{
    public float speed; // The current speed of the car
    public float speedThreshold = 55f; // Speed threshold to trigger the canvas
    public Canvas speedCanvas; // Reference to the canvas you want to trigger

    void Update()
    {
        // Calculate the car's current speed (example assumes you're using a rigidbody for physics)
        Rigidbody rb = GetComponent<Rigidbody>();
        speed = rb.velocity.magnitude * 5f; // Convert to km/h if velocity is in meters/second

        // Check if the speed exceeds the threshold
        if (speed > speedThreshold)
        {
            speedCanvas.gameObject.SetActive(true); // Show the canvas
        }
        else
        {
            speedCanvas.gameObject.SetActive(false); // Hide the canvas
        }
    }

    public float GetSpeed(){
       return speed;
    }
}
