using UnityEngine;
using UnityEngine.UI;
public class GunBehavior : MonoBehaviour {

    public float fireRate = 0.0f;
    public float heat = 0.0f;
    public string weaponName;
	public Slider charge;

    public float nextFire = 0.0f;
    public float heatBuildUp = 0.0f;

	private Slider sliderController;

    public GunBehavior(string newWeaponName, float newFireRate, float newHeat) {
        weaponName = newWeaponName;
        fireRate = newFireRate;
        heat = newHeat;
	}

	void Start() {
		GameObject canvas = GameObject.Find ("CanvasRenderer");
		GameObject sliderObject = Instantiate (Resources.Load("GunCooldownSlider"), canvas.transform) as GameObject;
		sliderController = sliderObject.GetComponent<Slider> ();
	}

	void Update() {
		setSliderValue ();
	}

    public void Trigger() {
        if(Time.time > nextFire) {
            Fire();
        }
    }

    public float HeatTransfer() {
        float heatToTransfer = heatBuildUp;
        heatBuildUp = 0.0f;
        return heatToTransfer;
    }

    private void Fire() {
        Debug.unityLogger.Log("INFO", string.Format("Gun: {0} Triggered", weaponName));
        Exhaust();
        nextFire = Time.time + fireRate;
		sliderController.minValue = Time.time;
		sliderController.maxValue = nextFire;
    }

    private void Exhaust() {
        heatBuildUp += heat; ;
    }

	private void setSliderValue() {
		sliderController.value = Time.time;
	}
}
