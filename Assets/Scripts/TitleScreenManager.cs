using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenManager : MonoBehaviour
{
    public Image[] characterButtons;
    public Sprite brownBorder;
    public Sprite greenBorder;

    public Animator panelAnimatorCharacter;
    public Animator panelAnimatorMain;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        updateBorders();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void exitGame()
    {
        Application.Quit();
    }

    

    public void characterSelectMenuOpen()
    {
        panelAnimatorCharacter.Play("SlideInPanel");
        

    }

    public void characterSelectMenuClose()
    {
        panelAnimatorCharacter.Play("SlideOutPanel");
              
    }

    public void minigamesOpen()
    {
        panelAnimatorMain.Play("mainPanelSlideOut");
    }
    public void minigamesClose()
    {
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
