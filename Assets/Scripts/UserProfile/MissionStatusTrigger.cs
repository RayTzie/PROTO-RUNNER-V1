using UnityEngine;

public class MissionStatusTrigger : MonoBehaviour
{
    public MissionStatusManager missionStatusManager; // Reference to the MissionStatusManager script
    public GameObject TargetObject; // The object that triggers the mission status (e.g., the player)

    private void Start()
    {
        if (TargetObject == null)
        {
            Debug.LogWarning("TargetObject is not assigned. Please assign the object that should trigger the mission status.");
        }

        if (missionStatusManager == null)
        {
            Debug.LogWarning("MissionStatusManager is not assigned. Please assign the MissionStatusManager script.");
        }
    }

    // Called when a collider enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the specified TargetObject
        if (other.gameObject == TargetObject)
        {
            // Call the UpdateMissionStatus method on the MissionStatusManager to check the mission status
            missionStatusManager.UpdateMissionStatus();
        }
    }
}
