using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform player;                   // The player (car) object to follow
    public LineRenderer lineRenderer;          // The LineRenderer for the path
    public Transform[] waypoints;              // Waypoints for the line renderer

    void Start()
    {
        // Draw the initial route on the LineRenderer
        DrawRoute();
    }

    void LateUpdate()
    {
        // Update the position of the minimap camera to follow the player
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;  // Maintain the same height for the minimap camera
        transform.position = newPosition;

        // Rotate the minimap camera to match the player's Y rotation
        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }

    void DrawRoute()
    {
        // Check if lineRenderer and waypoints are valid
        if (lineRenderer != null && waypoints.Length > 0)
        {
            // Set the number of points in the LineRenderer
            lineRenderer.positionCount = waypoints.Length;

            // Set each position in the LineRenderer
            for (int i = 0; i < waypoints.Length; i++)
            {
                lineRenderer.SetPosition(i, waypoints[i].position);
            }
        }
    }
}
