using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SecretButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image leftEye;
    public Image rightEye;

    // Detect when the mouse enters the secret button
    public void OnPointerEnter(PointerEventData eventData)
    {
        leftEye.color = new Color32(255,0,0,100);
        rightEye.color = new Color32(255,0,0,100);
    }
        
    // Detect when the mouse leaves the secret button
    public void OnPointerExit(PointerEventData eventData)
    {
        leftEye.color = new Color32(255,255,255,0);
        rightEye.color = new Color32(255,255,255,0);
    }
}
