using UnityEngine;

public class OnTriggerEnterAndExit : MonoBehaviour
{
	  // Reference to the UserProfile ScriptableObject
    public UserProfile userProfile;

    // Canvases for mission status
    public Canvas missionPassedCanvas;
    public Canvas missionFailedCanvas;

	public GameObject TargetObject;
	public GameObject Canvas;

	public KeyCode pauseKey = KeyCode.Escape;
	public bool isPaused = false;

	void Start()
	{
		TargetObject = GameObject.Find("No Left Turn Sign");
	}

	void Update(){
		if (Input.GetKeyDown (pauseKey)) {
			isPaused = !isPaused;
			PauseGame (isPaused);
		}
	}

	void PauseGame(bool paused)
	{
		Time.timeScale = paused ? 0f : 1f;
	}

	public void CloseWindow(){
		isPaused = !isPaused;
		PauseGame (isPaused);
		//Canvas.SetActive (false);
		 missionPassedCanvas.gameObject.SetActive(false);

	}

	// Called when a collider enters the trigger
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			//Canvas.SetActive (true);
			isPaused = !isPaused;
			PauseGame (isPaused);
			//Debug.Log ("On Trigger Enter Detected!");
			 // Check and display the mission status when the script starts
            UpdateMissionStatus();
		}
	}

	// Called when a collider exits the trigger
	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			//Debug.Log ("On Trigger Exit Detected!");
			//Canvas.SetActive (false);
			 missionPassedCanvas.gameObject.SetActive(false);

		}
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
