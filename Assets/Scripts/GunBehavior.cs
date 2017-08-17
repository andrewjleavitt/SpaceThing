using UnityEngine;

public class GunBehavior {

    public float fireRate = 0.0f;
    public float heat = 0.0f;
    public string weaponName;

    private float nextFire = 0.0f;
    private float heatBuildUp = 0.0f;

    public GunBehavior(string newWeaponName, float newFireRate, float newHeat) {
        weaponName = newWeaponName;
        fireRate = newFireRate;
        heat = newHeat;
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
        Debug.unityLogger.Log("INFO", string.Format("Player Gun: {0} Triggered", weaponName));
        Exhaust();
        nextFire = Time.time + fireRate;
    }

    private void Exhaust() {
        heatBuildUp += heat; ;
    }
}
