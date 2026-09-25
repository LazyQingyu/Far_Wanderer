using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public GameObject projectil;
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
        if (Input.GetKey(KeyCode.Space))
        {
            Instantiate(projectil, transform.position+Vector3.up, Quaternion.identity);
        }
        
    }

    void MovePlayer()
    {
        if (isMoving)
        {
            transform.position += moveToNewPosition;
            isMoving = false;
        }
        
    }
}
