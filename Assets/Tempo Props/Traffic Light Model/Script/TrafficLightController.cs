using UnityEngine;
using UnityEngine.UI;

public class TrafficLightController : MonoBehaviour
{
    public GameObject redLight;        // Reference to Red Light GameObject
    public GameObject yellowLight;     // Reference to Yellow Light GameObject
    public GameObject greenLight;      // Reference to Green Light GameObject

    public Text timerText;             // Reference to the UI Text component for displaying the timer

    public float redLightDuration = 5f;    // Duration for red light
    public float yellowLightDuration = 2f; // Duration for yellow light
    public float greenLightDuration = 5f;  // Duration for green light

    public string timeFormat = ""; // String format for displaying time (e.g., "00", "000", "0.0")

    private enum LightState { Red, Yellow, Green }
    private LightState currentState;
    private float timer;

    void Start()
    {
        currentState = LightState.Red;    // Start with red light
        timer = redLightDuration;         // Initialize timer with red light duration
        UpdateLights();                   // Update lights on start
        UpdateTimerText();                // Show initial timer value
    }

    void Update()
    {
        timer -= Time.deltaTime;           // Decrease timer every frame

        if (timer <= 0)
        {
            SwitchLightState();            // Switch state when timer runs out
            UpdateLights();                // Update lights after switch
        }

        UpdateTimerText();                 // Update the timer text every frame
    }

    void SwitchLightState()
    {
        switch (currentState)
        {
            case LightState.Red:
                currentState = LightState.Green;
                timer = greenLightDuration;  // Reset timer for green light
                break;

            case LightState.Green:
                currentState = LightState.Yellow;
                timer = yellowLightDuration; // Reset timer for yellow light
                break;

            case LightState.Yellow:
                currentState = LightState.Red;
                timer = redLightDuration;    // Reset timer for red light
                break;
        }
    }

    void UpdateLights()
    {
        // Enable/Disable lights based on current state
        redLight.SetActive(currentState == LightState.Red);
        yellowLight.SetActive(currentState == LightState.Yellow);
        greenLight.SetActive(currentState == LightState.Green);
    }

    void UpdateTimerText()
    {
        if (timerText != null)
        {
            // Convert timer to an integer and ensure no negative values
            int displayTime = Mathf.CeilToInt(Mathf.Max(timer, 0));

            // Format the timer value using the format string specified in the Inspector
            string formattedTime = displayTime.ToString(timeFormat);

            // Update the timer text in UI
            timerText.text = formattedTime;

            // Change the text color based on the current light state
            switch (currentState)
            {
                case LightState.Red:
                    timerText.color = Color.red;
                    break;
                case LightState.Yellow:
                    timerText.color = Color.yellow;
                    break;
                case LightState.Green:
                    timerText.color = Color.green;
                    break;
            }
        }
    }
}
