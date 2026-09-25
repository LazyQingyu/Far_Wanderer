using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class ProjectilCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Alien"))
        {   
            Destroy(collision.gameObject);
            Destroy(gameObject);
            CommonResource.instance.alienInSwarm.RemoveAll(item => item == null);
        }else if (collision.gameObject.CompareTag("AlienSoldier"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }else if (collision.gameObject.CompareTag("AlienCaptain"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    
    }

}
