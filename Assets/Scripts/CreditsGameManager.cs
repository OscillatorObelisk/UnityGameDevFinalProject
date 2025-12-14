using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsGameManager : MonoBehaviour
{
    private bool ready = false;

    void Start()
    {
        StartCoroutine(end());
    }
    private void Update()
    {
        if (ready)
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("TitleScreen");
            }
        }
    }

    private IEnumerator end()
    {
        yield return new WaitForSeconds(3f);

        ready = true;
    }
}
