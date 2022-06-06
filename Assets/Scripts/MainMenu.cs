using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject character1;
    public GameObject character2;
    public GameObject character3;

    // Start is called before the first frame update
    void Start()
    {
        string difficulty = PlayerPrefs.GetString("Difficulty", "Medium");
        PlayerPrefs.SetString("Difficulty", difficulty);
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

    public void swipeControlsEnabled(bool enabled)
    {
        if(enabled)
        {
            PlayerPrefs.SetString("ControlType", "Swipe");
        }
        else
        {
            PlayerPrefs.SetString("ControlType", "Tap");
        }
    }

    public void StartGame()
    {
        if(character1.activeSelf)
        {
            PlayerPrefs.SetInt("Character", 0);
        }
        else if(character2.activeSelf)
        {
            PlayerPrefs.SetInt("Character", 1);
        }
        else if(character3.activeSelf)
        {
            PlayerPrefs.SetInt("Character", 2);
        }
        SceneManager.LoadScene("EndlessMode");
    }

    public void ExitGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
