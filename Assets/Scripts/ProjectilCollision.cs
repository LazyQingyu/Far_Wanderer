using UnityEngine;

public class ProjectilCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision : i'm "+gameObject.name);
        Debug.Log("Collision with : "+collision.gameObject.name);
    }
}
