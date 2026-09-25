using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public GameObject Player;
    Vector3 moveToNewPosition;

    public float playerSpeed;
    bool isMoving = false;

    void Update()
    {
        KeyPressed();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void KeyPressed()
    {
        if (Input.GetKey(KeyCode.A))
        {
            moveToNewPosition = new Vector3(-playerSpeed, 0, 0);
            isMoving = true;

        }
        if (Input.GetKey(KeyCode.D))
        {
            moveToNewPosition = new Vector3(playerSpeed, 0, 0);
            isMoving = true;
        }
    }

    void MovePlayer()
    {
        if (isMoving)
        {
            Player.transform.position += moveToNewPosition;
            isMoving = false;
        }
        
    }
}
