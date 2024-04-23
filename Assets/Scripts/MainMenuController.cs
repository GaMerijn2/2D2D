using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LevelScene()
    {
        SceneManager.LoadScene("LevelScene");

    }

    public void CreditScene()
    {
        SceneManager.LoadScene("CreditScene");

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}