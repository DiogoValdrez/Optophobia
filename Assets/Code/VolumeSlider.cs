using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider slider;

    public void SetVolume(){
        GameManager.instance.SetVolume(slider.value);
        AudioListener.volume = GameManager.instance.volume;
    }
    void Update()
    {
        slider.value = GameManager.instance.volume;
    }
}
