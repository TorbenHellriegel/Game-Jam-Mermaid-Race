using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FlashText : MonoBehaviour
{
    public TMP_Text flickerText;
    public Image flickerImage;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(StartFlashText), 1.0f, 2.0f);
    }

    IEnumerator StartFlashText()
    {
        flickerText.enabled = false;
        flickerImage.enabled = false;
        yield return new WaitForSeconds(0.2f);
        flickerText.enabled = true;
        flickerImage.enabled = true;
        yield return new WaitForSeconds(0.2f);
    }
}
