using UnityEngine;

public class ProjectilCollision : MonoBehaviour
{
    public float addTime;
    void OnCollisionEnter2D(Collision2D collision)
    {
        CommonResource.instance.AddTime(addTime);
        Destroy(gameObject);
    }
}
