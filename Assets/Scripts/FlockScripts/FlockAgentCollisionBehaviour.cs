using UnityEngine;

public class FlockAgentCollisionBehaviour : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("projectil"))
        {
            Debug.Log(gameObject.name+" get hit by a "+collision.gameObject.name+". I need help!!! BOOOOOOM");
        }
    }
}
