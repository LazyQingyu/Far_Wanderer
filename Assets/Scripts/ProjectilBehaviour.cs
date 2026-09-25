using UnityEngine;
using System.Collections;

public class ProjectilBehaviour : MonoBehaviour
{

    public GameObject playerPosition;
    public float projectilSpeed;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(moveProjectil());
    }



    IEnumerator moveProjectil()
    {   
        while (gameObject !=null && transform.position.y < 6.0f )
        {
            yield return new WaitForSeconds(0.01f);
            transform.position += new Vector3(0, projectilSpeed * Time.deltaTime, 0);
        }
        if(gameObject != null)
        {
            Destroy(gameObject);
        }
    }

}
