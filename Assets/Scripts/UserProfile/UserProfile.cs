using UnityEngine;

[CreateAssetMenu(fileName = "NewUserProfile", menuName = "User Profile", order = 51)]
public class UserProfile : ScriptableObject
{
    public string playerName;
    public Sprite playerPicture;
    public int score;

    // Function to update the score
    public void UpdateScore(int scoreIncrement)
    {
        score -= scoreIncrement;
    }
}
