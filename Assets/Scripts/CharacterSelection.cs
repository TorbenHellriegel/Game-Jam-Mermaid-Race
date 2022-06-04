using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;
    public int activeCharacter;

    void Start()
    {
        activeCharacter = 0;
        ActivateCharacter(activeCharacter);
    }
    
    public void NextActiveCharacter()
    {
        activeCharacter++;
        if(activeCharacter >= characters.Length)
        {
            activeCharacter = 0;
        }
        ActivateCharacter(activeCharacter);
    }

    public void PreviousActiveCharacter()
    {
        activeCharacter--;
        if(activeCharacter < 0)
        {
            activeCharacter = characters.Length - 1;
        }
        ActivateCharacter(activeCharacter);
    }

    private void ActivateCharacter(int index)
    {
        for (int i = 0; i < characters.Length; i++)
        {
            if(i == index)
            {
                characters[i].SetActive(true);
            }
            else
            {
                characters[i].SetActive(false);
            }
        }
    }
}
