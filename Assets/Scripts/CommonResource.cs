using System.Collections.Generic;
using UnityEngine;

public class CommonResource : MonoBehaviour
{
    public static CommonResource instance;

    public List<GameObject> deadFlockAgent;

    void Awake()
    {
        instance = this;
        deadFlockAgent = new List<GameObject>();
    }

}
