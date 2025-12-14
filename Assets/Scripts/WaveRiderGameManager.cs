using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class WaveRiderGameManager : MonoBehaviour
{
    public static WaveRiderGameManager Instance;

    public CinemachineCamera Camera;

    public GameObject endPanel;
    public GameObject endText;
    public GameObject pauseMenu;

    public bool finished = false;

    public GameObject next;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerData.currentLevel = 1;
    }

    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reachFinishLine()
    {
        Camera.Follow = null;
        StartCoroutine(ShowEndPanelDelayed());
    }

    public void restartLevel()
    {
        SceneManager.LoadScene("WaveRider");
    }

    public void exitLevel()
    {
        SceneManager.LoadScene("TitleScreen");
    }
    public void nextLevel()
    {
        SceneManager.LoadScene("Tutorial2");
    }

    private IEnumerator ShowEndPanelDelayed()
    {
        Destroy(pauseMenu);
        finished = true;
        yield return new WaitForSeconds(3f);

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
