using System.Collections.Generic;
using UnityEngine;

public class CommonResource : MonoBehaviour
{
    public static CommonResource instance;

    public List<GameObject> alienInSwarm;
    [SerializeField]
    public Dictionary<string,Vector3> listAliansPosition;

    public GameObject firstEnemy;
    public GameObject secondEnemy;
    public GameObject thirdEnemy;

    void Awake()
    {
        instance = this;
        alienInSwarm = new List<GameObject>();
        listAliansPosition = new Dictionary<string, Vector3>();
    }

    public GameObject getEnemyPrefabByNumber(int number)
    {
        switch (number)
        {
            case 1:
                return firstEnemy;
            case 2:
                return secondEnemy;
            case 3:
                return thirdEnemy;
            default:
                return null;
        }
    }

}
