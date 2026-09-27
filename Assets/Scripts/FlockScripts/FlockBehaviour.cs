using UnityEngine;
using System.Collections.Generic;
public abstract class FlockBehaviour : ScriptableObject
{
    public abstract Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock);

}
