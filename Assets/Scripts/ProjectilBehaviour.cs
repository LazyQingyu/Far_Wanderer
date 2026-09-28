using UnityEngine;
public class ProjectilBehaviour : MonoBehaviour
{
    public float projectilSpeed;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        moveProjectil();
    }

    void moveProjectil()
    {   
        rb.linearVelocity = transform.right * projectilSpeed * Time.deltaTime;
        Destroy(gameObject,4f);
    }

}
