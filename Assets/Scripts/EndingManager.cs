using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class EndingManager : MonoBehaviour
{
    public Image myImage;
    public GameObject prompt;

    private bool faded = false;

    void Start()
    {
        StartCoroutine(FadeOut());
    }
    private void Update()
    {
        if(faded)
        {
            prompt.SetActive(true);
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("Credits");
            }
        }
    }

    private IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(3f);

        myImage.CrossFadeAlpha(0.0f, 1.0f, false);

        yield return new WaitForSeconds(2f);

        faded = true;
    }
}
