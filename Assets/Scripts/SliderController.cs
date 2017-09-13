using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SliderController : MonoBehaviour {

    Slider slider;
    private float value;

	void Start () {
        slider = gameObject.GetComponent<Slider>();
	}
	
	void Update () {
        slider.value = value;
    }

    public void setMinMax(float min, float max) {
        slider.minValue = min;
        slider.maxValue = max;
    }

    public void setSliderValue(float newValue) {
        value = newValue;
    }
}
