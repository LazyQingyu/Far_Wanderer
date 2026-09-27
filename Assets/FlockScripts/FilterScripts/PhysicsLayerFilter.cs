using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Flock/Filter/PhysicsLayer")]
public class PhysicsLayerFilter : ContextFilter
{
    public LayerMask mask;

    public override List<Transform> Filter(FlockAgent agent, List<Transform> original)
    {
        List<Transform> filtered = new List<Transform>();
        foreach (Transform obj in original)
        {
            if (mask == (mask | (1 << obj.gameObject.layer)))
            {
                filtered.Add(obj);
            }
        }
        return filtered;
    }

}
