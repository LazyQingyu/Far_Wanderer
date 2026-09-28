using UnityEngine;

public class FlockAgentCollisionBehaviour : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("projectil"))
        {
            CommonResource.instance.deadFlockAgent = gameObject.GetComponentInChildren<FlockAgent>();
            
        }
    }
}
