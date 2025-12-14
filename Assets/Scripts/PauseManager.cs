using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;

    public AudioSource audioSource;
    public AudioClip clickSFX;
    public AudioClip backSFX;

    public bool isPaused = false;

    public GameObject resumeButton;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            if (pauseMenu.activeSelf)
            {
                resume();
            }           
            else
            {
                audioSource.PlayOneShot(clickSFX);
                pause();
            }           
        }
    }

    public void pause()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        StartCoroutine(SetSelection(resumeButton));
    }

    public void resume()
    {
        isPaused = false;
        audioSource.PlayOneShot(backSFX);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void returnToTitle()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScreen");
    }

    IEnumerator SetSelection(GameObject button)
    {
        yield return null;
        EventSystem.current.SetSelectedGameObject(button);
    }
}
