using System;
using UnityEngine;
using UnityEngine.UI;

public class HeatsinkBehavior : MonoBehaviour {

    public float sinkRate = 1.0f;
    public float heatThreshold = 0.0f;

    private float sinkAmount = 1.0f;
    private float currentHeat = 0.0f;
    private float nextSink = 0.0f;

    private Slider slider;
    private SliderController sliderScript;
    private bool isSliderInitialized = false;

    void Start() {
        InitSlider();
    }

    void Update() {
        if (!isSliderInitialized) {
            sliderScript.setMinMax(0.0f, heatThreshold);
            isSliderInitialized = true;
        }
        sliderScript.setSliderValue(currentHeat);

        if (Time.time < nextSink) {
            return;
        }

        currentHeat = Mathf.Max(0.0f, currentHeat-= sinkAmount);
        nextSink = Time.time + sinkRate;

    }

    public void SinkHeat(float heat) {
        currentHeat += heat;
    }

    internal bool IsOverheating() {
        return currentHeat > heatThreshold;
    }

    void InitSlider() {
        GameObject canvas = GameObject.Find("CanvasRenderer");
        VerticalLayoutGroup sliderLayoutGroup = canvas.GetComponent<VerticalLayoutGroup>();
        GameObject sliderObject = Instantiate(Resources.Load("MySlider"), sliderLayoutGroup.transform) as GameObject;
        slider = sliderObject.GetComponent<Slider>();
        sliderScript = slider.GetComponent<SliderController>();
    }
}
