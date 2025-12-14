using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PunchManager : MonoBehaviour
{
    public static PunchManager Instance;

    public GameObject Spawner1;
    public GameObject Spawner2;
    public GameObject Spawner3;

    public GameObject endPanel;
    public GameObject endText;
    public GameObject pauseMenu;

    public bool finished = false;

    public GameObject next;

    private void Start()
    {
        PlayerData.currentLevel = 2;
    }
    void Awake()
    {
        Instance = this;
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
        SceneManager.LoadScene("Tutorial3");
    }

    private IEnumerator ShowEndPanelDelayed()
    {
        Destroy(pauseMenu);

        yield return new WaitForSeconds(6f);

        finished = true;

        endPanel.SetActive(true);
        endText.SetActive(true);

        StartCoroutine(SetSelection(next));
    }

    IEnumerator SetSelection(GameObject button)
    {
        yield return null;
        EventSystem.current.SetSelectedGameObject(button);
    }
}
