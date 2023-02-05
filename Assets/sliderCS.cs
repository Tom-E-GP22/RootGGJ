using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderCS : MonoBehaviour
{
    Slider slider;
    float hSliderValue;

    void Start()
    {
        slider= GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        hSliderValue = slider.value;
        hSliderValue = GUI.HorizontalSlider(new Rect(940, 135 + (Mathf.Sin(hSliderValue * -.0175f) * 30), 243, 30), hSliderValue, 0.0f, 180.0f);
    }
}
