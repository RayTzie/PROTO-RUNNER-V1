using UnityEngine;

public class MissionStatusManager : MonoBehaviour
{
    // Reference to the UserProfile ScriptableObject
    public UserProfile userProfile;

    // Canvases for mission status
    public Canvas missionPassedCanvas;
    public Canvas missionFailedCanvas;

    private void Start()
    {
        // Check and display the mission status when the script starts
        UpdateMissionStatus();
    }

    // Method to update and display the mission status
    public void UpdateMissionStatus()
    {
        if (userProfile != null)
        {
            // Check the value of roadtrafficsignscore
            if (userProfile.roadtrafficsignscore >= 80)
            {
                // Show the Mission Passed Canvas
                missionPassedCanvas.gameObject.SetActive(true);
                missionFailedCanvas.gameObject.SetActive(false);
            }
            else
            {
                // Show the Mission Failed Canvas
                missionPassedCanvas.gameObject.SetActive(false);
                missionFailedCanvas.gameObject.SetActive(true);
            }
        }
    }
}
