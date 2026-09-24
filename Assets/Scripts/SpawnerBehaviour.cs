
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;



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

    enum DirectionMovement
    {
        Left,
        Right,
        Down,
        Up
    };

    List<GameObject> listAlien = new List<GameObject>();

    public GameObject firstEnemy;
    public GameObject secondEnemy;
    public GameObject thirdEnemy;

    public float delaysBeforeAliensMovement;
    public float aliensMovementSpeed;

    Coroutine moveAliensCoroutine;

    float AxeX = 8.5f;
    float AxeY = 4.5f;

    public float raduisAlien;

    void Start()
    {
        InstantiateAliensGroup(-3, 4, aliensMap2);
        moveAliensCoroutine = null;

    }

    private void FixedUpdate()
    {
        // if(moveAliensCoroutine == null)
        // {
        //     moveAliensCoroutine = StartCoroutine(MoveAliens(delaysBeforeAliensMovement));
        // }
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

    //Region AlienSwamMovement

    bool InZoneAllowed(float pos, string movement)
    {
        if (movement == "Horizontal")
        {
            return (-AxeX < pos && pos < AxeX);
        }
        else
        {
            return (-AxeY < pos && pos < AxeY);
        }
    }

    void moveHorizontaly(List<GameObject> aliansWhoIsAlive, float moveBy)
    {
        foreach(GameObject alien in aliansWhoIsAlive)
        {
            float currentAlienPosX = alien.transform.position.x;
            float currentAlienPosY = alien.transform.position.y;
            if(InZoneAllowed(currentAlienPosX + moveBy, "Horizontal") && IsMyNextPosAllowed(alien, aliansWhoIsAlive, ("Horizontal",moveBy)))
            {
                alien.transform.position = new Vector3(currentAlienPosX + moveBy, currentAlienPosY, 0);
            }
        }
    }

    void moveVerticaly(List<GameObject> aliansWhoIsAlive, float moveBy)
    {
        foreach (GameObject alien in aliansWhoIsAlive)
        {
            float currentAlienPosX = alien.transform.position.x;
            float currentAlienPosY = alien.transform.position.y;
            if (InZoneAllowed(currentAlienPosY + moveBy, "Verticaly") && IsMyNextPosAllowed(alien, aliansWhoIsAlive, ("Verticaly", moveBy)))
            {
                alien.transform.position = new Vector3(currentAlienPosX, currentAlienPosY + moveBy, 0);
            }
        }
    }

    bool IsMyNextPosAllowed(GameObject alien, List<GameObject> alienSwam, (string,float) move)
    {

        (float, float) alienNextPos = getNextPos(alien, move);
        foreach( GameObject oneAlienInSwarm in alienSwam)
        {
            if (!HaveSamePos(alien, oneAlienInSwarm))
            {
                if (CollisionAfterMove(alienNextPos, oneAlienInSwarm)){
                    return false;
                }
            }
        }
        return true;
    }

    bool HaveSamePos(GameObject alien, GameObject oneAlienInSwarm)
    {
        return (alien.transform.position.x == oneAlienInSwarm.transform.position.x && alien.transform.position.y == oneAlienInSwarm.transform.position.y);
    }

    bool CollisionAfterMove((float, float) posAlienAfterMove, GameObject oneAlienInSwarm)
    {
      float distanceBetweenCircles = Mathf.Sqrt(Mathf.Pow(posAlienAfterMove.Item1 - oneAlienInSwarm.transform.position.x, 2) + Mathf.Pow(posAlienAfterMove.Item2 - oneAlienInSwarm.transform.position.y, 2));
      if (distanceBetweenCircles < raduisAlien * 2)
      {
          return true;
      }
      return false;
    }

    (float, float) getNextPos(GameObject alien,(string, float) move)
    {
        (float, float) nextPos;
        if (move.Item1 == "Horizontal")
        {
            nextPos.Item1 = alien.transform.position.x + move.Item2;
            nextPos.Item2 = alien.transform.position.y;
        }
        else
        {
            nextPos.Item1 = alien.transform.position.x;
            nextPos.Item2 = alien.transform.position.y + move.Item2;
        }

        return nextPos;
    }
    //EndRegion AlienSwamMovement

    DirectionMovement MoveProbability()
    {
        int probability = UnityEngine.Random.Range(0, 101);

        if(probability < 5)
        {
            return DirectionMovement.Down;
        }
        else if(5 < probability && probability < 15)
        {
            return DirectionMovement.Up;
        }
        else if(15 < probability && probability < 52)
        {
            return DirectionMovement.Left;
        }
        else
        {
            return DirectionMovement.Right;
        }   
    }

    void AlienSwarmMovement()
    {
        
        DirectionMovement randomMove = MoveProbability();
        
        switch (randomMove)
        {
            case DirectionMovement.Left:
                moveHorizontaly(listAlien, -aliensMovementSpeed);
                break;
            case DirectionMovement.Right:
                moveHorizontaly(listAlien, aliensMovementSpeed);
                break;
            case DirectionMovement.Down:
                moveVerticaly(listAlien, -aliensMovementSpeed);
                break;
            case DirectionMovement.Up:
                moveVerticaly(listAlien, aliensMovementSpeed);
                break;
        } 
    }

    IEnumerator MoveAliens(float time)
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(time);
            AlienSwarmMovement();
        }
    }

}
