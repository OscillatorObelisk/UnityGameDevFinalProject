using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StarlessAbstractGameManager : MonoBehaviour
{
    public float timeLimit = 45f;
    private float timer;

    public GameObject Spawner1;
    public GameObject Spawner2;
    public GameObject Spawner3;

    public GameObject endPanel;
    public GameObject endText;
    public GameObject pauseMenu;

    public GameObject next;

    public bool finished = false;
    void Start()
    {
        timer = timeLimit;
        PlayerData.currentLevel = 3;

        StartCoroutine(activateSpawners());
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            timer = 0f;
            endSequence();
        }
    }

    public void endSequence()
    {
        Destroy(Spawner1);
        Destroy(Spawner2);
        Destroy(Spawner3);
        StartCoroutine(ShowEndPanelDelayed());
    }

    public void exitLevel()
    {
        SceneManager.LoadScene("TitleScreen");
    }
    public void nextLevel()
    {
        SceneManager.LoadScene("Ending");
    }

    private IEnumerator ShowEndPanelDelayed()
    {
        Destroy(pauseMenu);

        yield return new WaitForSeconds(5f);
        
        finished = true;

        endPanel.SetActive(true);
        endText.SetActive(true);

        StartCoroutine(SetSelection(next));
    }

    private IEnumerator activateSpawners()
    {
        yield return new WaitForSeconds(3f);

        Spawner1.SetActive(true);
        Spawner2.SetActive(true);
        Spawner3.SetActive(true);
    }

    IEnumerator SetSelection(GameObject button)
    {
        yield return null;
        EventSystem.current.SetSelectedGameObject(button);
    }
}
