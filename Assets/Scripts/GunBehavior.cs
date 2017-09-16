using UnityEngine;
using UnityEngine.UI;
public class GunBehavior : MonoBehaviour {

    public float fireRate = 0.0f;
    public float heat = 0.0f;
    public string weaponName;
    public Slider charge;

    public float nextFire = 0.0f;
    public float heatBuildUp = 0.0f;

    private Slider slider;
    private SliderController sliderScript;
    private bool isSliderInitialized;

    void Start() {
		InitSlider();
    }

    private void Update() {
        if (!isSliderInitialized) {
            sliderScript.setMinMax(Time.time, nextFire);
            isSliderInitialized = true;
        }

        sliderScript.setSliderValue(Time.time);
    }

    public void Trigger() {
        if (Time.time > nextFire) {
            Fire();
        }
    }

    public float HeatTransfer() {
        float heatToTransfer = heatBuildUp;
        heatBuildUp = 0.0f;
        return heatToTransfer;
    }

    private void Fire() {
        Random rand = new Random();
        Debug.unityLogger.Log("INFO", string.Format("Gun: {0} Triggered", weaponName));
        Instantiate(
            Resources.Load("Missile"),
            GetComponentInParent<PlayerSpaceShip>().transform.position,
            new Quaternion(90f, 0f, Random.Range(0.0f, 180.0f), 0.0f)
        );
        Exhaust();
        nextFire = Time.time + fireRate;
        sliderScript.setMinMax(Time.time, nextFire);
    }

    private void Exhaust() {
        heatBuildUp += heat; ;
    }

	void InitSlider() {
		GameObject canvas = GameObject.Find("CanvasRenderer");
		VerticalLayoutGroup sliderLayoutGroup = canvas.GetComponent<VerticalLayoutGroup>();
		GameObject sliderObject = Instantiate(Resources.Load ("MySlider"), sliderLayoutGroup.transform) as GameObject;
		slider = sliderObject.GetComponent<Slider>();
		sliderScript = slider.GetComponent<SliderController>();
    }
}