using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Toggle ControlToggle;

    public GameObject[] character;

    public GameObject gameModeTutorial;
    public GameObject gameModeEndless;

    // Start is called before the first frame update
    void Start()
    {
        string difficulty = PlayerPrefs.GetString("Difficulty", "Medium");
        PlayerPrefs.SetString("Difficulty", difficulty);
        PlayerPrefs.SetString("ControlType", PlayerPrefs.GetString("ControlType", "Tap"));
    }

    public void ExitButton()
    {
        #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
                             Application.OpenURL(webplayerQuitURL);
        #else
                             Application.Quit();
        #endif
        
        Debug.Log("Game Closed");
    }

    public void SwipeControlsEnabled()
    {
        if(ControlToggle.isOn)
        {
            PlayerPrefs.SetString("ControlType", "Swipe");
        }
        else
        {
            PlayerPrefs.SetString("ControlType", "Tap");
        }
    }

    public void SetControlsToggle()
    {
        if(PlayerPrefs.GetString("ControlType", "Tap") == "Swipe" )
        {
            ControlToggle.isOn = true;
        }
        else
        {
            ControlToggle.isOn = false;
        }
    }

    public void StartGame()
    {
        if(character[0].activeSelf)
        {
            PlayerPrefs.SetInt("Character", 0);
        }
        else if(character[1].activeSelf)
        {
            PlayerPrefs.SetInt("Character", 1);
        }
        else if(character[2].activeSelf)
        {
            PlayerPrefs.SetInt("Character", 2);
        }

        if(gameModeTutorial.activeSelf)
        {
            SceneManager.LoadScene("Tutorial");
        }
        else if(gameModeEndless.activeSelf)
        {
            SceneManager.LoadScene("EndlessMode");
        }
    }

    public void ExitGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
