using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HeatsinkSliderController : MonoBehaviour {

    Slider slider;

    void Start() {
        slider = GetComponent<Slider>();
    }

    public void setMinMax(float min, float max) {
        slider.minValue = min;
        slider.maxValue = max;
    }
}
