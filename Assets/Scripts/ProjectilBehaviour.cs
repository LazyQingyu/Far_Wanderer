using UnityEngine;
public class ProjectilBehaviour : MonoBehaviour
{
    public float projectilSpeed;

    void Update()
    {
        moveProjectil();
    }

    void moveProjectil()
    {   
        // if(!isOffScreen())
        // {
        transform.position += transform.position * projectilSpeed * Time.deltaTime;
        
        Destroy(gameObject,3f);
    }

}
