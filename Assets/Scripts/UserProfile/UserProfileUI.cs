using UnityEngine;
using UnityEngine.UI;
using TMPro; // Import the TextMeshPro namespace

public class UserProfileUI : MonoBehaviour
{
    public UserProfile userProfile;  // Reference to the Scriptable Object

    // UI elements to display the profile data
    public TextMeshProUGUI playerNameText;  // TextMeshPro element for player name
    public Image playerPictureImage;        // Image component for player picture
    public TextMeshProUGUI playerScoreText; // TextMeshPro element for player score

    private void Start()
    {
        // Update the UI with the data from the ScriptableObject and PlayerPrefs
        UpdateUserProfileUI();
    }

    private void UpdateUserProfileUI()
    {
        if (userProfile != null)
        {
            // Set the player name and picture from the UserProfile ScriptableObject
            playerNameText.text = userProfile.playerName;
            playerPictureImage.sprite = userProfile.playerPicture;

            // Load the player score from PlayerPrefs
            int savedScore = PlayerPrefs.GetInt("PlayerScore", userProfile.score); // Default to ScriptableObject score if PlayerPrefs has no saved data
            playerScoreText.text = savedScore.ToString() + "%";
        }
    }
}
