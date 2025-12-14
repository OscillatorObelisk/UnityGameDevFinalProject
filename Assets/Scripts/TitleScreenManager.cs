using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class TitleScreenManager : MonoBehaviour
{
    public Image[] characterButtons;
    public Sprite brownBorder;
    public Sprite greenBorder;

    public Animator panelAnimatorCharacter;
    public Animator panelAnimatorMain;

    public AudioSource audioSource;
    public AudioClip clickSFX;
    public AudioClip backSFX;

    public GameObject characterSelectButton;
    public GameObject defaultCharacterButton;
    public GameObject waveFantasyButton;
    public GameObject freePlayButton;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        updateBorders();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SetSelection(GameObject button)
    {
        yield return null;
        EventSystem.current.SetSelectedGameObject(button);
    }


    public void exitGame()
    {
        Application.Quit();
    }

    public void loadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    

    public void characterSelectMenuOpen()
    {
        audioSource.PlayOneShot(clickSFX);
        StartCoroutine(SetSelection(defaultCharacterButton));
        panelAnimatorCharacter.Play("SlideInPanel");
    }

    public void characterSelectMenuClose()
    {
        audioSource.PlayOneShot(backSFX);
        StartCoroutine(SetSelection(characterSelectButton));
        panelAnimatorCharacter.Play("SlideOutPanel");
              
    }

    public void minigamesOpen()
    {
        audioSource.PlayOneShot(clickSFX);
        StartCoroutine(SetSelection(waveFantasyButton));
        panelAnimatorMain.Play("mainPanelSlideOut");
    }
    public void minigamesClose()
    {
        audioSource.PlayOneShot(backSFX);
        StartCoroutine(SetSelection(freePlayButton));
        panelAnimatorMain.Play("mainPanelSlideIn");
    }

    public void minigameWave()
    {
        SceneManager.LoadScene("WaveRider");
    }
    public void minigameStarless()
    {
        SceneManager.LoadScene("StarlessAbstract");
    }
    public void minigamePunchIn()
    {
        SceneManager.LoadScene("PunchIn");
    }

    public void play()
    {
        SceneManager.LoadScene("Tutorial1");
    }


    public void selectCharacter(int characterID)
    {
        audioSource.PlayOneShot(clickSFX);
        PlayerData.selectedCharacter = characterID;
        //Debug.Log("Selected character: " + PlayerData.selectedCharacter);

        updateBorders();
    }

    public void updateBorders()
    {
        for (int i = 0; i < characterButtons.Length; i++)
        {
            if (i == PlayerData.selectedCharacter)
                characterButtons[i].sprite = greenBorder;
            else
                characterButtons[i].sprite = brownBorder;
        }
    }
}
