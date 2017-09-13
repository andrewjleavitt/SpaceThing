using System;
using UnityEngine;
using UnityEngine.UI;

public class HeatsinkBehavior : MonoBehaviour {

    public float sinkRate = 1.0f;
    public float heatThreshold = 0.0f;

    private float sinkAmount = 1.0f;
    private float currentHeat = 0.0f;
    private float nextSink = 0.0f;
	private HeatsinkSliderController sliderScript;

    void Start() {
        InitSlider();
    }

    private void Update() {
        if(Time.time > nextSink) { 
            currentHeat = Mathf.Max(0, currentHeat-= sinkAmount);
        }

    }

    public void SinkHeat(float heat) {
        currentHeat += heat;
    }

    internal bool IsOverheating() {
        return currentHeat > heatThreshold;
    }

    private void InitSlider() {
        GameObject canvas = GameObject.Find("CanvasRenderer");
        VerticalLayoutGroup sliderLayouGroup = canvas.GetComponent<VerticalLayoutGroup>();
        GameObject sliderObject = Instantiate(Resources.Load("HeatsinkSlider"), sliderLayouGroup.transform) as GameObject;
        Slider slider = sliderObject.GetComponent<Slider>();
        sliderScript = slider.GetComponent<HeatsinkSliderController>();
    }
}
