using UnityEngine;
using TMPro;

public class ScoreUpdater : MonoBehaviour
{
    public UserProfile userProfile;  // Reference to the UserProfile ScriptableObject
    public TextMeshProUGUI playerScoreText; // Reference to the score Text UI element

    private void Start()
    {
        // Load the saved score from PlayerPrefs when the game starts
        LoadUserProfile();
        UpdateScoreUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Replace with appropriate tag for the object
        {
            // Increment score when two objects collide
            userProfile.UpdateScore(10);  // Example increment of 10 points
            UpdateScoreUI();

            // Save the score to PlayerPrefs
            SaveUserProfile();
        }
    }

    // Update the UI with the current score
    private void UpdateScoreUI()
    {
        if (playerScoreText != null)
        {
            playerScoreText.text = userProfile.score.ToString();
        }
    }

    // Save the score to PlayerPrefs for persistence on mobile
    private void SaveUserProfile()
    {
        PlayerPrefs.SetInt("PlayerScore", userProfile.score);
        PlayerPrefs.Save(); // Ensure the data is written to storage
    }

    // Load the saved score from PlayerPrefs
    private void LoadUserProfile()
    {
        if (PlayerPrefs.HasKey("PlayerScore"))
        {
            userProfile.score = PlayerPrefs.GetInt("PlayerScore");
        }
    }
}
