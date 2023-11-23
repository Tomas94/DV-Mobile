using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void PlayLevel(string level)
    {
        if (GameManager.Instance.stamina <= 0) return;
        StartCoroutine(StartLevel(.25f, level));
    }

    public static void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    public static void ToMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public static void QuitGame()
    {
        Application.Quit();
    }

    public static void Pause()
    {
        Time.timeScale = 0f;
    }

    public static void Resume()
    {
        Time.timeScale = 1f;
    }

    IEnumerator StartLevel(float time, string EscenaACargar) 
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(EscenaACargar);
    }
}
