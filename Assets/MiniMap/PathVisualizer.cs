using UnityEngine;
using UnityEngine.AI;

public class PathVisualizer : MonoBehaviour
{
    public Transform destination;
    private NavMeshPath navPath;
    private LineRenderer lineRenderer;

    void Start()
    {
        navPath = new NavMeshPath();
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (NavMesh.CalculatePath(transform.position, destination.position, NavMesh.AllAreas, navPath))
        {
            lineRenderer.positionCount = navPath.corners.Length;
            lineRenderer.SetPositions(navPath.corners);
        }
    }
}
