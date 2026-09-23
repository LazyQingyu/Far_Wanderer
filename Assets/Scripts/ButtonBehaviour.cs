using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    public void GoToGame()
    {
        SceneManager.LoadSceneAsync("Game");
    }

    public void GoToScoreBoard()
    {
        SceneManager.LoadSceneAsync("ScoreBoard");
    }

}
