using UnityEngine;

public class RouteDrawer : MonoBehaviour
{
    public LineRenderer lineRenderer; // Assign this via inspector
    public Transform[] waypoints;     // Add waypoints in the inspector or dynamically

    void Start()
    {
        DrawRoute();
    }

    void DrawRoute()
    {
        lineRenderer.positionCount = waypoints.Length;
        for (int i = 0; i < waypoints.Length; i++)
        {
            lineRenderer.SetPosition(i, waypoints[i].position);
        }
    }

    void LateUpdate() // Optional: Update the line on each frame
    {
        DrawRoute();
    }
}
