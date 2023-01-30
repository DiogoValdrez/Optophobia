using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrbitSpeedSlider : MonoBehaviour
{
    public Slider slider;

    public void SetOrbitSpeed(){
        GameManager.instance.SetOrbitSpeed(slider.value);
    }
    void Update()
    {
        slider.value = GameManager.instance.OrbitSpeed*0.5f;
    }
}
