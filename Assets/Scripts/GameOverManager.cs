using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverManager : MonoBehaviour
{

    public GameObject retryButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SetSelection(retryButton));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void retryLevel()
    {
        if (PlayerData.currentLevel == 1)
        {
            SceneManager.LoadScene("WaveRider");
        }
        else if (PlayerData.currentLevel == 2)
        {
            SceneManager.LoadScene("PunchIn");
        }
        else if (PlayerData.currentLevel == 3)
        {
            SceneManager.LoadScene("StarlessAbstract");
        }
        else
        {
            Debug.Log("Something gone wrong dog");
        }
    }
    public void exitLevel()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    IEnumerator SetSelection(GameObject button)
    {
        yield return null;
        EventSystem.current.SetSelectedGameObject(button);
    }
}
