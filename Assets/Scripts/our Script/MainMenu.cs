using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        PlayerPrefs.DeleteAll();
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       
    }

    public void SettingsButton()
    {

    }

    public void QuitGame()
    {
        Debug.Log("QuitGame");
        Application.Quit();
    }

}