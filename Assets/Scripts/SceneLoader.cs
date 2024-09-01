using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void OnEnable()
    {
        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Unsubscribe from the sceneLoaded event to avoid memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void LoadSceneByName(string ingame)
    {
        // Start loading the scene
        SceneManager.LoadScene(ingame);
    }

    // This method is called when a new scene is loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the loaded scene matches the one you attempted to load
        if (scene.name == "ingame")
        {
            Debug.Log("Scene '" + scene.name + "' loaded successfully.");
        }
        else
        {
            Debug.Log("Loaded scene: " + scene.name);
        }
    }
}
