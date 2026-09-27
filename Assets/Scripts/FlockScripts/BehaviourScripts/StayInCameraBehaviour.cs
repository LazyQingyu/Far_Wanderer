using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/StayInCamera")]
public class StayInCameraBehaviour : FlockBehaviour
{
    public Vector3 center;
    public float radius = 10f;
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        Vector3 centerOffset = center - agent.transform.position;
        float distanceFromCenter = centerOffset.magnitude / radius;
        if (distanceFromCenter < 0.9f)
        {
            return Vector3.zero;
        }
        else
        {
            return centerOffset * distanceFromCenter * distanceFromCenter;
        }
    }
}
