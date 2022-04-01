using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameOver()
    {
        StartCoroutine(GameOver());
    }

    private static IEnumerator GameOver()
    {
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene("GameOver");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game");

        // Won't work for WebGL.
        Application.Quit();
    }
}
