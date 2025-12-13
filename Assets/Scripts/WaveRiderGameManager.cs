using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveRiderGameManager : MonoBehaviour
{
    public static WaveRiderGameManager Instance;

    public CinemachineCamera Camera;

    public GameObject endPanel;
    public GameObject endText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        yield return new WaitForSeconds(3f);

        endPanel.SetActive(true);
        endText.SetActive(true);
    }
}
