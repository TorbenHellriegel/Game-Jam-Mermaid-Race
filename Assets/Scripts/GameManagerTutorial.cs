using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerTutorial : MonoBehaviour
{
    public GameObject[] characters;

    public GameObject leftButton;
    public GameObject rightButton;
    public GameObject downButton;
    public GameObject okButton;
    public TextMeshProUGUI tutorialTextDisp;
    private int lastTutorialNumber;
    private bool tutorialFinished = false;

    private string[] tutorialText = {
        "Collect starfish to increase your score!",
        "Tap the right or left side of the screen to move right or left and avoid obstacles.",
        "Tap the bottom of the screen to dive under obstacles.",
        "Some obstacles you can't dive under. Dive ahead of time to jump out of the water over the obstacle.",
        "Some obstacles you can't dive under or jump over. You have to avoid them!",
        "That's it for the tutorial. You are now ready to surf on your own!"
    };

    void Start()
    {
        // Spawn the selected character
        int CharacterIndex = PlayerPrefs.GetInt("Character");
        characters[CharacterIndex].SetActive(true);
    }
    public void TutorialPrompt(int tutorialPromptNumber)
    {
        Time.timeScale = 0;
        switch (tutorialPromptNumber)
        {
            case 0:
                okButton.SetActive(true);
                tutorialTextDisp.gameObject.SetActive(true);
                tutorialTextDisp.text = tutorialText[tutorialPromptNumber];
                lastTutorialNumber = tutorialPromptNumber;
                break;
            case 1:
                leftButton.SetActive(true);
                rightButton.SetActive(true);
                tutorialTextDisp.gameObject.SetActive(true);
                tutorialTextDisp.text = tutorialText[tutorialPromptNumber];
                lastTutorialNumber = tutorialPromptNumber;
                break;
            case 2:
                leftButton.SetActive(false);
                rightButton.SetActive(false);
                downButton.SetActive(true);
                tutorialTextDisp.gameObject.SetActive(true);
                tutorialTextDisp.text = tutorialText[tutorialPromptNumber];
                lastTutorialNumber = tutorialPromptNumber;
                break;
            case 3:
                leftButton.SetActive(false);
                rightButton.SetActive(false);
                tutorialTextDisp.gameObject.SetActive(true);
                tutorialTextDisp.text = tutorialText[tutorialPromptNumber];
                lastTutorialNumber = tutorialPromptNumber;
                break;
            case 4:
                tutorialTextDisp.gameObject.SetActive(true);
                tutorialTextDisp.text = tutorialText[tutorialPromptNumber];
                lastTutorialNumber = tutorialPromptNumber;
                break;
            case 5:
                okButton.SetActive(true);
                tutorialTextDisp.gameObject.SetActive(true);
                tutorialTextDisp.text = tutorialText[tutorialPromptNumber];
                lastTutorialNumber = tutorialPromptNumber;
                tutorialFinished = true;
                break;
            default:
                break;
        }
    }

    public void Continue()
    {
        Time.timeScale = 1;
        tutorialTextDisp.gameObject.SetActive(false);
        okButton.SetActive(false);

        switch (lastTutorialNumber)
        {
            case 2: case 3:
                leftButton.SetActive(true);
                rightButton.SetActive(true);
                break;
            default:
                break;
        }

        if(tutorialFinished)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
