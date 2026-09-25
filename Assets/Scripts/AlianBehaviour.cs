using UnityEngine;

public class AlianBehaviour : MonoBehaviour
{
    string myName;

    void Awake()
    {
        myName = RandomString(21);
    }

    void Start()
    {
        SayToAnotherAlienMyPostion();
    }

    void SayToAnotherAlienMyPostion()
    {
        CommonResource.instance.listAliansPosition.Add(myName,transform.position);
        //Debug.Log($"My Alian name is {myName} and i'm at {transform.position}");
    }
    string RandomString(int size){
        string listCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string newString = "";
        for(int i = 0; i < size; i++)
        {
            newString+=listCharacters[Random.Range(0,listCharacters.Length)];
        }
        return newString;
    }

    public string getName()
    {
        return myName;
    }


    void OollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision in alian : "+gameObject.name);
    }
}
