using UnityEngine;
using UnityEngine.UI;

public class DigitalSpeedometer : MonoBehaviour
{
    public Text speedText; // Reference to the UI Text component
    private SimpleCarController speedometerValue; // Reference to the SimpleCarController

    private float updateInterval = 0.1f; // Time between updates in seconds
    private float timeSinceLastUpdate = 0f; // Timer to track time since last update

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            speedometerValue = player.GetComponent<SimpleCarController>();
        }

        if (speedometerValue == null)
        {
            Debug.LogError("SimpleCarController component not found on the player object.");
        }
    }

    void Update()
    {
        timeSinceLastUpdate += Time.deltaTime;

        if (timeSinceLastUpdate >= updateInterval)
        {
            if (speedometerValue != null)
            {
                // Get the speed from the SimpleCarController and remove the negative sign
                float speed = Mathf.Abs(speedometerValue.GetSpeedometer());

                // Update the text to display the speed
                speedText.text = "Speed: "+ Mathf.Round(speed).ToString() + " km/h";
            }
            else
            {
                speedText.text = "0 km/h";
            }

            // Reset the timer
            timeSinceLastUpdate = 0f;
        }
    }
}
