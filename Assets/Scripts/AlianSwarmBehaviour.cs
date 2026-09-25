using UnityEngine;

public class AlianSwarmBehaviour : MonoBehaviour
{
    int[,] aliansMap2 = {{0,0,0,3,0,0,0},
                         {0,0,3,3,3,0,0},
                         {0,2,2,2,2,2,0},
                         {0,2,2,2,2,2,0},
                         {0,0,1,1,1,0,0},
                         {0,0,0,1,0,0,0}
                        };


    void Start()
    {
        InstantiateAliansSwarm(-3,4,aliansMap2);
    }

    void InstantiateAliansSwarm(int startX, int startY, int[,] enemyMap )
    {
        Vector3 enemyPos;
        GameObject currentEnemy;
        for (int i = 0; i < enemyMap.GetLength(0); i++) {
            for (int j = 0; j < enemyMap.GetLength(1); j++) {

                enemyPos = new Vector3(j + startX, i + (startY-i)-i, 0);
                currentEnemy = CommonResource.instance.getEnemyPrefabByNumber(enemyMap[i,j]);
                
                if (currentEnemy != null)
                {
                   Instantiate(currentEnemy, enemyPos, Quaternion.identity);
                }
            }
        }
    }

    

}
