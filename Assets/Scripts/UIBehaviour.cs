using TMPro;
using UnityEngine;

public class UIBehaviour : MonoBehaviour
{
    public TextMeshProUGUI score;

    void Update()
    {
        score.text = "Score : " + CommonResource.instance.GetScore();
    }
}
