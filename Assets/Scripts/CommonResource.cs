using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class CommonResource : MonoBehaviour
{
    public static CommonResource instance;
    int score;

    public FlockAgent deadFlockAgent;

    public float time;

    void Awake()
    {
        instance = this;
        score = 0;
    }

    public float GetTime(){ return time; }
    public void UpdateTime(float currentTime){ time = currentTime;}
    public void AddTime(float plusTime){ time+= plusTime; }
    public void RemoveTime(float minusTime){ time-= minusTime;}
    public int GetScore() { return score; }
    public void UpdateScore(int point){ score+=point;}
}
