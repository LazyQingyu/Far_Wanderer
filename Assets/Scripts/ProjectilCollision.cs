using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class ProjectilCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision in Projectil : "+gameObject.name);
        Destroy(gameObject);
    }

}
