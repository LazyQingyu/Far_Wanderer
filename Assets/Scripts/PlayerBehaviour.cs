using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Player;
    Vector3 moveToNewPosition;

    public float playerSpeed;
    bool isMoving = false;

    // Update is called once per frame
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
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            moveToNewPosition = new Vector3(-playerSpeed, 0, 0);
            isMoving = true;

        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
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
