using UnityEngine;
using UnityEngine.UI;

public class HeatsinkBehavior : MonoBehaviour {

    public float sink = 1.0f;

    private float nextSink = 0.0f;
    private float rate = 0.0f;
	private SliderController sliderScript;

    public float Sink() {
        if (Time.time < nextSink) {
            return -1;
        }

        nextSink = Time.time + rate;
        return sink;
    }

	void InitSlider ()
	{
		GameObject canvas = GameObject.Find ("CanvasRenderer");
		VerticalLayoutGroup sliderLayouGroup = canvas.GetComponent<VerticalLayoutGroup> ();
		GameObject sliderObject = Instantiate (Resources.Load ("GunCooldownSlider"), sliderLayouGroup.transform) as GameObject;
		Slider slider = sliderObject.GetComponent<Slider> ();
		sliderScript = slider.GetComponent<SliderController> ();
	}
}
