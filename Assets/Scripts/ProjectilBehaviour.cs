using UnityEngine;
using System.Collections;

public class ProjectilBehaviour : MonoBehaviour
{
    public GameObject projectil;
    public GameObject playerPosition;
    public float projectilSpeed;
    GameObject newProjectil;
    void Start()
    {
        newProjectil = null;
    }

    // Update is called once per frame
    void Update()
    {
        KeyPressed();
    }

    void KeyPressed()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
        {
            if(newProjectil == null)
            {
                newProjectil = Instantiate(projectil, playerPosition.transform.position, Quaternion.identity);
                StartCoroutine(moveProjectil(newProjectil));
            }
        }
    }

    IEnumerator moveProjectil(GameObject newProjectil)
    {   
        while (newProjectil.transform.position.y < 6.0f)
        {
            yield return new WaitForSeconds(0.01f);
            newProjectil.transform.position += new Vector3(0, projectilSpeed * Time.deltaTime, 0);
        }
        Destroy(newProjectil);
    }

}
