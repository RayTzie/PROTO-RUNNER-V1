using UnityEngine;

public class OnTriggerEnterAndExit : MonoBehaviour
{
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
		Canvas.SetActive (false);
	}

	// Called when a collider enters the trigger
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			Canvas.SetActive (true);
			isPaused = !isPaused;
			PauseGame (isPaused);
			//Debug.Log ("On Trigger Enter Detected!");
		}
	}

	// Called when a collider exits the trigger
	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			//Debug.Log ("On Trigger Exit Detected!");
			Canvas.SetActive (false);

		}
	}
}
