using System;
using TMPro;
using UnityEngine;

public class UIBehaviour : MonoBehaviour
{
    public TextMeshProUGUI score;
    public AudioSource stageTheme;

    void Start()
    {
        stageTheme.Play();
    }

    void Update()
    {
        score.text = "Score : " + CommonResource.instance.GetScore();
    }
}
