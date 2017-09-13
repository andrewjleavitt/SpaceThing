using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class HeatsinkSliderController : MonoBehaviour {

    Slider slider;

    void Start() {
        slider = GetComponent<Slider>();
        Debug.unityLogger.Log(slider);
    }

    public void setMinMax(float min, float max) {
        slider.minValue = min;
        slider.maxValue = max;
    }

    public void setSliderValue(float value) {
        slider.value = value;
    }
}
