using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SliderController : MonoBehaviour {

    Slider slider;

	void Start () {
        slider = GetComponent<Slider>();
	}
	
	void Update () {
        slider.value = Time.time;
    }

    public void setMinMax(float min, float max) {
        slider.minValue = min;
        slider.maxValue = max;
    }
}
