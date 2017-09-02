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

    public GunBehavior(string newWeaponName, float newFireRate, float newHeat) {
        weaponName = newWeaponName;
        fireRate = newFireRate;
        heat = newHeat;
    }

    void Start() {
        GameObject canvas = GameObject.Find("CanvasRenderer");
        GameObject sliderObject = Instantiate(Resources.Load("GunCooldownSlider"), canvas.transform) as GameObject;
        slider = sliderObject.GetComponent<Slider>();
        sliderScript = slider.GetComponent<SliderController>();
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
        Debug.unityLogger.Log("INFO", string.Format("Gun: {0} Triggered", weaponName));
        Exhaust();
        nextFire = Time.time + fireRate;
        sliderScript.setMinMax(Time.time, nextFire);
    }

    private void Exhaust() {
        heatBuildUp += heat; ;
    }
}