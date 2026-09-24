using UnityEngine;

public class ProjectilCollision : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected");
        if(collision.gameObject.tag == "Alien")
        {
            // Destroy(collision.gameObject);
            // Destroy(newProjectil);
            Debug.Log("Collision with alien");
        }
    }

}
