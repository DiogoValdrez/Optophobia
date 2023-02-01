using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider slider;

    public void SetVolume(){
        PlayerPrefs.SetFloat("volume", slider.value);
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
    }
    void Update()
    {
        slider.value = PlayerPrefs.GetFloat("volume");
    }
}
