using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame1()
    {
        SceneManager.LoadScene("Course1");
    }
    public void StartGame2()
    {
        SceneManager.LoadScene("Course2");
    }
    public void StartGame3()
    {
        SceneManager.LoadScene("Course3");
    }
    public void StartGame4()
    {
        SceneManager.LoadScene("Course4");
    }
    public void StartGame5()
    {
        SceneManager.LoadScene("Course5");
    }
    public void GoToMenu()
    {
        Time.timeScale=1f;
        SceneManager.LoadScene("StartScene");
    }
}
