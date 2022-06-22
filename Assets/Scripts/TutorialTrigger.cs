using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    public int tutorialPromptNumber;
    private GameManagerTutorial tutorialManager;

    void Start()
    {
        tutorialManager = GameObject.Find("GameManager").GetComponent<GameManagerTutorial>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        tutorialManager.TutorialPrompt(tutorialPromptNumber);
        Destroy(gameObject);
    }
}
