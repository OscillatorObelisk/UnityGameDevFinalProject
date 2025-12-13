using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PunchManager : MonoBehaviour
{
    public static PunchManager Instance;

    public GameObject Spawner1;
    public GameObject Spawner2;
    public GameObject Spawner3;

    public GameObject endPanel;
    public GameObject endText;


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
        yield return new WaitForSeconds(8f);

        endPanel.SetActive(true);
        endText.SetActive(true);
    }
}
