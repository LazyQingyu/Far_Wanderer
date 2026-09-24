using UnityEngine;

public class ProjectilCollision : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected "+collision.gameObject.name);
    
    }

}
