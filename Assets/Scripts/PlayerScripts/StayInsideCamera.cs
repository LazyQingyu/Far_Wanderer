using UnityEngine;

public class StayInsideCamera : MonoBehaviour
{
 
    [SerializeField] private float AxeX = 8.5f;
    [SerializeField] private float AxeY = 4.5f;
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -AxeX, AxeX),
            Mathf.Clamp(transform.position.y, -AxeY, AxeY),
            transform.position.z
        );
    }
}
