using UnityEngine;

public class ScoreBehaviour : MonoBehaviour
{
    int score = 0;
    public GameObject scoreText;

    public void AddScore(int points)
    {
        score += points;
        scoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + score;
    }

}
