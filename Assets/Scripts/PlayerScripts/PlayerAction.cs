using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public GameObject projectilPrefab;
    public Transform launchOffset;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(projectilPrefab, launchOffset.position, transform.rotation);
        }
    }
}
