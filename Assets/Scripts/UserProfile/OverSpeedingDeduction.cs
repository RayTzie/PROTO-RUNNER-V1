using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OverSpeedingDeduction : MonoBehaviour
{
    public UserProfile userProfile;  // Reference to the UserProfile ScriptableObject
    public TextMeshProUGUI playerScoreText; // Reference to the score Text UI element
    public Text roadtrafficsignScoreText; // Reference to the Road Traffic Sign Text UI element


    public float speed; // The current speed of the car
    public float speedThreshold = 20f; // Speed threshold to trigger the animation
    public Text scoreText; // Reference to the score text object that shows the penalty
    public ScoreAnimation scoreAnimation; // Reference to the ScoreAnimation component

    private bool hasUpdatedUserScore = false; // Flag to check if the user score has been updated
    private bool hasUpdateRoadTrafficSignScore = false; // Flag to check if the user score has been updated
    void Start()
    {
        // Load the saved score from PlayerPrefs when the game starts
        LoadUserProfile();
        UpdateScoreUI(); // Initial score UI update
        UpdateRoadTrafficSignScoreUI(); // Initial Road Traffic sign score UI update

        // Get the ScoreAnimation component attached to the scoreText object
        scoreAnimation = scoreText.GetComponent<ScoreAnimation>();
        if (scoreAnimation == null)
        {
            Debug.LogWarning("ScoreAnimation component not found on the scoreText GameObject.");
        }
    }

    void Update()
    {
        // Calculate the car's current speed (assuming a Rigidbody for physics)
        Rigidbody rb = GetComponent<Rigidbody>();
        speed = rb.velocity.magnitude * 5f; // Convert to km/h if velocity is in meters/second

        // Check if the speed exceeds the threshold
        if (speed > speedThreshold)
        {
            // Update score and UI if not already updated for this threshold
            if (!hasUpdatedUserScore && !hasUpdateRoadTrafficSignScore)  
            {
                // Show the score text and trigger animation
                scoreText.gameObject.SetActive(true); // Show the score text
                scoreText.text = "-7"; // Update the score display text
                scoreAnimation.PlayAnimation(); // Play the fade and fly-up animation

                // Update user score and UI
                userProfile.UpdateScore(7);  // Example increment of 10 points
                userProfile.UpdateRoadTrafficSignScore(7);  // Example increment of 10 points


                UpdateScoreUI(); // Update the score UI
                UpdateRoadTrafficSignScoreUI(); // Update the Road Sign score UI
                SaveUserProfile(); // Save the updated score to PlayerPrefs

                // Set the flag to indicate that the user score has been updated
                hasUpdatedUserScore = true;

                 // Set the flag to indicate that the user  Road Traffic Sign score has been updated
                hasUpdateRoadTrafficSignScore = true;
            }

        }
        else
        {
            // Hide the score text if not over-speeding
            scoreText.gameObject.SetActive(false);

            // Reset the score update flag if speed is below the threshold
            hasUpdatedUserScore = false; // Reset flag to allow for future updates

            // Reset the Road Traffic Sign score update flag if speed is below the threshold
            hasUpdateRoadTrafficSignScore = false; // Reset flag to allow for future updates
        }

        // Always update the player score UI to reflect the current score
        UpdateScoreUI();
        UpdateRoadTrafficSignScoreUI();

    }

    public float GetSpeed()
    {
        return speed;
    }

    // Update the UI with the current score
    private void UpdateScoreUI()
    {
        if (playerScoreText != null)
        {
            playerScoreText.text = userProfile.score.ToString() + "%";
        }
    }


       // Update the Road Sign Score UI with the current score
    private void UpdateRoadTrafficSignScoreUI()
    {
        if (roadtrafficsignScoreText != null)
        {
            roadtrafficsignScoreText.text = userProfile.roadtrafficsignscore.ToString() + "%";
        }
    }

    // Save the score to PlayerPrefs for persistence
    private void SaveUserProfile()
    {
        PlayerPrefs.SetInt("PlayerScore", userProfile.score);
        PlayerPrefs.SetInt("RoadTrafficSignScore", userProfile.roadtrafficsignscore);
        PlayerPrefs.Save(); // Ensure the data is written to storage
    }

    // Load the saved score from PlayerPrefs
    private void LoadUserProfile()
    {
        if (PlayerPrefs.HasKey("PlayerScore"))
        {
            userProfile.score = PlayerPrefs.GetInt("PlayerScore");
        }

           if (PlayerPrefs.HasKey("RoadTrafficSignScore"))
        {
            userProfile.roadtrafficsignscore = PlayerPrefs.GetInt("RoadTrafficSignScore");
        }
    }
}
