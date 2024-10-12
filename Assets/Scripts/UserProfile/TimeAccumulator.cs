using UnityEngine;
using UnityEngine.UI;
using TMPro; // Import the TextMeshPro namespace

public class TimeAccumulator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText; // Reference to the TextMeshProUGUI element
    [SerializeField] private float timeThreshold = 60f; // Configurable time threshold in seconds
    [SerializeField] private UserProfile userProfile; // Reference to the UserProfile ScriptableObject

    private float accumulatedTime = 0f; // Time accumulator
    private bool counted = false; // Flag to ensure the counter increments once

        // UI elements to display the profile data
    public Text totalDriveSignScoreText;     // TextMeshPro element for total drive sign score
   


    void Update()
    {
        // Accumulate time since the last frame
        accumulatedTime += Time.deltaTime;

        // Update the TextMeshProUGUI to show the accumulated time in minutes and seconds
        int minutes = (int)(accumulatedTime / 60); // Calculate the minutes
        int seconds = (int)(accumulatedTime % 60); // Calculate the remaining seconds
        timeText.text = string.Format("Time: {0:D2}:{1:D2}", minutes, seconds); // Display time in MM:SS format

        // Check if the accumulated time is greater than or equal to the configurable time threshold
        if (accumulatedTime >= timeThreshold && !counted)
        {
            userProfile.totaldrivesignscore += 1; // Increment the total drive sign score
            counted = true; // Set the flag to true to avoid counting again
            Debug.Log("Total Drive Sign Score: " + userProfile.totaldrivesignscore);

            // Optionally, reset accumulated time if you want to continue counting for further thresholds
            //accumulatedTime = 0f; // Reset the accumulated time for the next cycle
            //counted = false; // Reset the flag to allow counting in the next cycle

            SaveUserProfileData();
            UpdateUserProfileUI();
        }
    }

    private void UpdateUserProfileUI()
    {
        if (userProfile != null)
        {
            // Set the player name and picture from the UserProfile ScriptableObject
            //playerNameText.text = userProfile.playerName;
            //playerPictureImage.sprite = userProfile.playerPicture;

            // Display the scores in the UI
            //playerScoreText.text = userProfile.score.ToString() + "%";
            //roadTrafficSignScoreText.text = userProfile.roadtrafficsignscore.ToString() + "%";
            //pavementMarkingSignScoreText.text = userProfile.pavementmarkingsignscore.ToString() + "%";
            //drivingOnTheRoadSignScoreText.text = userProfile.drivingontheroadsignscore.ToString()+ "%";
            totalDriveSignScoreText.text = userProfile.totaldrivesignscore.ToString();
           
        }
    }



    public void SaveUserProfileData()
    {
        if (userProfile != null)
        {
            // Save the profile data to PlayerPrefs for persistence
            PlayerPrefs.SetString("PlayerName", userProfile.playerName);
            PlayerPrefs.SetInt("PlayerScore", userProfile.score);
            PlayerPrefs.SetInt("RoadTrafficSignScore", userProfile.roadtrafficsignscore);
            PlayerPrefs.SetInt("PavementMarkingSignScore", userProfile.pavementmarkingsignscore);
            PlayerPrefs.SetInt("DrivingOnTheRoadSignScore", userProfile.drivingontheroadsignscore);
            PlayerPrefs.SetInt("TotalDriveSignScore", userProfile.totaldrivesignscore);
            PlayerPrefs.SetInt("ReadableSignScore", userProfile.readablesignscore);
            PlayerPrefs.Save(); // Ensure the data is written to storage

            Debug.Log("User profile data saved to PlayerPrefs.");
        }
    }
}
