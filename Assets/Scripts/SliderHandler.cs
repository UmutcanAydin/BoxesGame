using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderHandler : MonoBehaviour
{
    public Slider slider;
    public AudioMixer mixer;
    public string exposedMixerVar = "MusicVol";
    public string prefName = "MusicValue";

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat(prefName);
    }

    private void Update()
    {
        PlayerPrefs.SetFloat(prefName, slider.value);
    }

    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat(exposedMixerVar, Mathf.Log10(sliderValue) * 20);
    }
}
