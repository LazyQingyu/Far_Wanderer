using System.Collections.Generic;
using UnityEngine;

public class CommonResource : MonoBehaviour
{
    public static CommonResource instance;

    public FlockAgent deadFlockAgent;

    void Awake()
    {
        instance = this;
        
    }

}
