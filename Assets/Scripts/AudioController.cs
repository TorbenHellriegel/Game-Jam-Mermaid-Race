using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{    
    [SerializeField] public AudioMixer audioMixer;
    [SerializeField] string masterParameter = "Master";
    [SerializeField] public Slider mvSlider;
    [SerializeField] string musicParameter = "Music";
    [SerializeField] public Slider musicSlider;
    [SerializeField] string sfxParameter = "SFX";
    [SerializeField] public Slider sfxSlider;
    [SerializeField] float multiplier = 30.0f;

    private void Awake()
    {
        mvSlider.onValueChanged.AddListener(HandleSliderValueChangeMaster);
        musicSlider.onValueChanged.AddListener(HandleSliderValueChangeMusic);
        sfxSlider.onValueChanged.AddListener(HandleSliderValueChangeSfx);
    }

    private void Start()
    {
        mvSlider.value = PlayerPrefs.GetFloat(masterParameter, mvSlider.value);
        mvSlider.value = PlayerPrefs.GetFloat(musicParameter, mvSlider.value);
        mvSlider.value = PlayerPrefs.GetFloat(sfxParameter, mvSlider.value);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(masterParameter, mvSlider.value);
    }
    private void HandleSliderValueChangeMaster(float value)
    {
        if(value == 0)
        {
            audioMixer.SetFloat(masterParameter, -80);
        }
        else
        {
            audioMixer.SetFloat(masterParameter, Mathf.Log10(value) * multiplier);
        }
    }
    private void HandleSliderValueChangeMusic(float value)
    {
        if(value == 0)
        {
            audioMixer.SetFloat(musicParameter, -80);
        }
        else
        {
            audioMixer.SetFloat(musicParameter, Mathf.Log10(value) * multiplier);
        }
    }
    private void HandleSliderValueChangeSfx(float value)
    {
        if(value == 0)
        {
            audioMixer.SetFloat(sfxParameter, -80);
        }
        else
        {
            audioMixer.SetFloat(sfxParameter, Mathf.Log10(value) * multiplier);
        }
    }
}
