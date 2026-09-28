using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    float remainingTime;


    void GetCurrentTime()
    {
        remainingTime = CommonResource.instance.GetTime();
    }
    public void AddTime(float time){ remainingTime += time;}
    public void MinusTime(float time){ remainingTime -= time;}
    void Update()
    {
        GetCurrentTime();
        if(remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }else if (remainingTime < 0)
        {
            remainingTime = 0;
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        CommonResource.instance.UpdateTime(remainingTime);
    }
}
