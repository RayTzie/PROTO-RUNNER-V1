using UnityEngine;
using UnityEngine.UI;
using TMPro; // Import the TextMeshPro namespace

public class UserProfileUI : MonoBehaviour
{
    public UserProfile userProfile;  // Reference to the ScriptableObject

    // UI elements to display the profile data
    public TextMeshProUGUI playerNameText;               // TextMeshPro element for player name
    public Image playerPictureImage;                    // Image component for player picture
    public TextMeshProUGUI playerScoreText;             // TextMeshPro element for player score
    public Text roadTrafficSignScoreText;    // TextMeshPro element for road traffic sign score
    public Text pavementMarkingSignScoreText; // TextMeshPro element for pavement marking sign score
    public Text drivingOnTheRoadSignScoreText; // TextMeshPro element for driving on the road sign score
    public Text totalDriveSignScoreText;     // TextMeshPro element for total drive sign score
    public Text readableSignScoreText;       // TextMeshPro element for readable sign score

    private void Start()
    {
        // Load and update the UI with the data from the ScriptableObject and PlayerPrefs
        LoadUserProfileData();
        UpdateUserProfileUI();
    }

    private void UpdateUserProfileUI()
    {
        if (userProfile != null)
        {
            // Set the player name and picture from the UserProfile ScriptableObject
            playerNameText.text = userProfile.playerName;
            playerPictureImage.sprite = userProfile.playerPicture;

            // Display the scores in the UI
            playerScoreText.text = userProfile.score.ToString() + "%";
            roadTrafficSignScoreText.text = userProfile.roadtrafficsignscore.ToString() + "%";
            pavementMarkingSignScoreText.text = userProfile.pavementmarkingsignscore.ToString() + "%";
            drivingOnTheRoadSignScoreText.text = userProfile.drivingontheroadsignscore.ToString()+ "%";
            totalDriveSignScoreText.text = userProfile.totaldrivesignscore.ToString() + "%";
            readableSignScoreText.text = userProfile.readablesignscore.ToString()+ "%";
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

    public void LoadUserProfileData()
    {
        if (userProfile != null)
        {
            // Load the profile data from PlayerPrefs if it exists
            if (PlayerPrefs.HasKey("PlayerName"))
            {
                userProfile.playerName = PlayerPrefs.GetString("PlayerName");
            }

            if (PlayerPrefs.HasKey("PlayerScore"))
            {
                userProfile.score = PlayerPrefs.GetInt("PlayerScore");
            }

            if (PlayerPrefs.HasKey("RoadTrafficSignScore"))
            {
                userProfile.roadtrafficsignscore = PlayerPrefs.GetInt("RoadTrafficSignScore");
            }

            if (PlayerPrefs.HasKey("PavementMarkingSignScore"))
            {
                userProfile.pavementmarkingsignscore = PlayerPrefs.GetInt("PavementMarkingSignScore");
            }

            if (PlayerPrefs.HasKey("DrivingOnTheRoadSignScore"))
            {
                userProfile.drivingontheroadsignscore = PlayerPrefs.GetInt("DrivingOnTheRoadSignScore");
            }

            if (PlayerPrefs.HasKey("TotalDriveSignScore"))
            {
                userProfile.totaldrivesignscore = PlayerPrefs.GetInt("TotalDriveSignScore");
            }

            if (PlayerPrefs.HasKey("ReadableSignScore"))
            {
                userProfile.readablesignscore = PlayerPrefs.GetInt("ReadableSignScore");
            }

            Debug.Log("User profile data loaded from PlayerPrefs.");
        }
    }

    public void ResetUserProfileData()
    {
        if (userProfile != null)
        {
            // Reset the user profile data to its default values
            userProfile.ResetValues();
            UpdateUserProfileUI();
            Debug.Log("User profile data has been reset.");
        }
    }
}
