using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (pauseMenu.activeSelf)
            {
                resume();
            }           
            else
            {
                pause();
            }           
        }
    }

    public void pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void returnToTitle()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScreen");
    }
}
