using UnityEngine;

public class PlayerCollisionBehaviour : MonoBehaviour
{
    public float minusTime;
    void OnCollisionEnter2D(Collision2D collision)
    {
        CommonResource.instance.RemoveTime(minusTime);
    }
}
