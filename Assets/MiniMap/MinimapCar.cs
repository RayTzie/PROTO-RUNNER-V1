using UnityEngine;

public class MinimapCar : MonoBehaviour
{
    public Transform car; // Assign the player's car transform in the inspector

    void Update()
    {
        // Check if the car reference is not null
        if (car != null)
        {
            // Set the minimap car's position to the car's position (ignore the Y axis)
            Vector3 minimapPosition = new Vector3(car.position.x, 0.1f, car.position.z); // Adjust Y to ensure it is above the ground
            transform.position = minimapPosition;

            // Debugging logs
            Debug.Log("Car Position: " + car.position + " Minimap Icon Position: " + transform.position);
        }
    }
}
