using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject character1;
    public GameObject character2;
    public GameObject character3;

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
        SceneManager.LoadScene("SwimmingPool");
    }
}
