using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerTutorial : MonoBehaviour
{
    public GameObject leftButton;
    public GameObject rightButton;
    public GameObject downButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TutorialPrompt(int tutorialPromptNumber)
    {
        Time.timeScale = 0;
    }
}
