using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(UserProfile))]
public class UserProfileEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Draw the default inspector UI
        DrawDefaultInspector();

        // Get a reference to the UserProfile script
        UserProfile userProfile = (UserProfile)target;

        // Add a space in the inspector
        GUILayout.Space(10);

        // Add a button to reset all values
        if (GUILayout.Button("Reset All Values"))
        {
            userProfile.ResetValues();
            EditorUtility.SetDirty(userProfile); // Mark the object as dirty to register changes
        }
        // Add a button to save the user profile to PlayerPrefs
        if (GUILayout.Button("Save User Profile"))
        {
            userProfile.SaveUserProfile();
            Debug.Log("User profile saved to PlayerPrefs.");
        }

        // Add a button to load the user profile from PlayerPrefs
        if (GUILayout.Button("Load User Profile"))
        {
            userProfile.LoadUserProfile();
            EditorUtility.SetDirty(userProfile); // Mark the object as dirty to register changes
            Debug.Log("User profile loaded from PlayerPrefs.");
        }

        // Add a button to save changes to the asset
        if (GUILayout.Button("Save Changes"))
        {
            AssetDatabase.SaveAssets(); // Save all changes to assets
        }
    }
}
