using NUnit.Framework;
using UnityEngine;
using Unity.Collections;
using System.Collections.Generic;
using System;

public class SpawnerBehaviour : MonoBehaviour
{
    int[,] aliensMap = {{3,3,3,3,3,3,3},
                        {0,2,2,2,2,2,0},
                        {0,0,2,2,2,0,0},
                        {0,1,1,1,1,1,0},
                        {1,1,1,1,1,1,1}
                        };

    int[,] aliensMap2 = {{0,0,0,3,0,0,0},
                         {0,0,3,3,3,0,0},
                         {0,2,2,2,2,2,0},
                         {0,2,2,2,2,2,0},
                         {0,0,1,1,1,0,0},
                         {0,0,0,1,0,0,0}
                        };

    List<GameObject> listAlien = new List<GameObject>();

    public GameObject firstEnemy;
    public GameObject secondEnemy;
    public GameObject thirdEnemy;

    void Start()
    {
        InstantiateAliensGroup(-3, 4, aliensMap2);
    }

    private void FixedUpdate()
    {
        moveHorizontaly(listAlien, -8.5f, -1);
    }
    public void InstantiateAliensGroup(int startX, int startY, int[,] enemyMap )
    {
        Vector3 enemyPos;
        GameObject currentEnemy;

        for (int i = 0; i < enemyMap.GetLength(0); i++) {
            for (int j = 0; j < enemyMap.GetLength(1); j++) {

                enemyPos = new Vector3(givePosX(startX, j), givePosY(startY-i, i), 0);
                currentEnemy = getEnemyPrefabByNumber(enemyMap[i,j]);
                
                if (currentEnemy != null)
                {
                   listAlien.Add(Instantiate(currentEnemy, enemyPos, Quaternion.identity));
                }
            }

        }

    }

    int givePosX(int startX, int i)
    {
        return i + startX;
    }

    int givePosY(int startY, int j)
    {
        return j + (startY-j);
    }

    GameObject getEnemyPrefabByNumber(int number)
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


    void moveHorizontaly(List<GameObject> aliansWhoIsAlive, float maxPossibleMove, float moveBy)
    {
        foreach(GameObject alien in aliansWhoIsAlive)
        {
            float currentAlienPosX = alien.transform.position.x;
            float currentAlienPosY = alien.transform.position.y;
            if(currentAlienPosX + moveBy > maxPossibleMove)
            {
                alien.transform.position = new Vector3(currentAlienPosX + moveBy, currentAlienPosY, 0);
            }
        }
    }

    void moveVerticaly(List<GameObject> aliansWhoIsAlive, float maxPossibleMove, float moveBy)
    {
        foreach (GameObject alien in aliansWhoIsAlive)
        {
            float currentAlienPosX = alien.transform.position.x;
            float currentAlienPosY = alien.transform.position.y;
            if (currentAlienPosY + moveBy < maxPossibleMove)
            {
                alien.transform.position = new Vector3(currentAlienPosX, currentAlienPosY + moveBy, 0);
            }
        }
    }

    bool CanMove(GameObject alien, List<GameObject> alienSwam, (string,float) Move)
    {

        foreach( GameObject oneAlienInSwamp in alienSwam)
        {

            if (!IsMySelf(alien, oneAlienInSwamp))
            {

            }
        }
        return true;
    }

    bool IsMySelf(GameObject alien, GameObject oneAlienInSwam)
    {
        return (alien.transform.position.x == oneAlienInSwam.transform.position.x && alien.transform.position.y == oneAlienInSwam.transform.position.y);
    }




}
