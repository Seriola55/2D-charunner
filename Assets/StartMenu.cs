using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame1()
    {
        SceneManager.LoadScene("Course1");
    }
    public void GoToMenu()
    {
        Time.timeScale=1f;
        SceneManager.LoadScene("StartScene");
    }
}
