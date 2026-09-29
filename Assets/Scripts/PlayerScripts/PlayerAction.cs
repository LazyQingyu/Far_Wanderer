using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public GameObject projectilPrefab;
    public Transform launchOffset;
    public AudioSource laserSFX;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            laserSFX.Play();
            Instantiate(projectilPrefab, launchOffset.position, transform.rotation);
        }
    }
}
