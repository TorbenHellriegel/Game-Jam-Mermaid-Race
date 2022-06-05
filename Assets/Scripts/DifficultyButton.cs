using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    public string difficulty = "Medium";
    private Button btn;

    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Button" + difficulty);
        // Debug.Log("game" + PlayerPrefs.GetString("Difficulty"));
        if(PlayerPrefs.GetString("Difficulty") == difficulty)
        {
            btn.Select();
        }
    }

    public void SetDifficulty()
    {
        PlayerPrefs.SetString("Difficulty", difficulty);
	}
}
