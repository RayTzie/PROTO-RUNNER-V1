using UnityEngine;

[CreateAssetMenu(fileName = "NewUserProfile", menuName = "User Profile", order = 51)]
public class UserProfile : ScriptableObject
{
    public string playerName;
    public Sprite playerPicture;
    public int score;
    public int roadtrafficsignscore;
    public int pavementmarkingsignscore;
    public int drivingontheroadsignscore;
    public int totaldrivesignscore;
    public int readablesignscore;

    // Function to update the score
    public void UpdateScore(int scoreIncrement)
    {
        score -= scoreIncrement;
    }

        // Function to update the Road Traffic sign Score
    public void UpdateRoadTrafficSignScore(int RoadTrafficSignscoreIncrement)
    {
        roadtrafficsignscore -= RoadTrafficSignscoreIncrement;
    }

    // Function to reset all values
    public void ResetValues()
    {
        //playerName = string.Empty;
        //playerPicture = null;
        score = 100;
        roadtrafficsignscore = 100;
        pavementmarkingsignscore = 100;
        drivingontheroadsignscore = 100;
        totaldrivesignscore = 0;
        readablesignscore = 0;
    }

    // Save the score to PlayerPrefs for persistence on mobile
    public void SaveUserProfile()
    {
        PlayerPrefs.SetInt("PlayerScore", score);
        PlayerPrefs.SetInt("RoadTrafficSignScore", roadtrafficsignscore);
        PlayerPrefs.SetInt("PavementMarkingSignScore", pavementmarkingsignscore);
        PlayerPrefs.SetInt("DrivingOnTheRoadSignScore", drivingontheroadsignscore);
        PlayerPrefs.SetInt("TotalDriveSignScore", totaldrivesignscore);
        PlayerPrefs.SetInt("ReadableSignScore", readablesignscore);
        PlayerPrefs.Save(); // Ensure the data is written to storage
    }

    // Load the saved score from PlayerPrefs
    public void LoadUserProfile()
    {
        if (PlayerPrefs.HasKey("PlayerScore"))
        {
            score = PlayerPrefs.GetInt("PlayerScore");
            roadtrafficsignscore = PlayerPrefs.GetInt("RoadTrafficSignScore");
            pavementmarkingsignscore = PlayerPrefs.GetInt("PavementMarkingSignScore");
            drivingontheroadsignscore = PlayerPrefs.GetInt("DrivingOnTheRoadSignScore");
            totaldrivesignscore = PlayerPrefs.GetInt("TotalDriveSignScore");
            readablesignscore = PlayerPrefs.GetInt("ReadableSignScore");
        }
    }
}
