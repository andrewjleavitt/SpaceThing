using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceShip : MonoBehaviour {

    public int hp = 0;
    public int level = 0;
    public float heatThreshold = 0.0f;

    public ArmorBehavior armor;
    public ShieldBehavior shield;
    public Dictionary <string, GunBehavior> guns = new Dictionary<string, GunBehavior>();
    public HeatsinkBehavior heatsink;

    void Start() {
        GunBehavior peaShooter = makeGun("Pea Shooter", 1.0f, 3.0f);
        GunBehavior mallowGun = makeGun("Mallow Gun", 1.0f, 1.0f);
        GunBehavior wristRocket = makeGun("Wrist Rocket", 0.8f, 1.1f);

        shield = new ShieldBehavior("Mighty Shield", 10.0f, 0.5f);
        armor = new ArmorBehavior("Cardboard", 100.0f);
		makeHeatsink (10.0f, 2.0f);
        heatsink = gameObject.GetComponent<HeatsinkBehavior>();

        guns.Add("first", peaShooter);
        guns.Add("second", mallowGun);
        guns.Add("third", wristRocket);
    }

    void Update () {
        if (!heatsink.IsOverheating()) {
            GetUserAction();
        }
        RegenerateShields();
    }

    private void RegenerateShields() {
        shield.Recharge();
    }

    private void GetUserAction() {
        if (Input.GetKeyDown("a")) {
            FireGunInPosition("first");
        } else if (Input.GetKeyDown("s")) {
            FireGunInPosition("second");
        } else if (Input.GetKeyDown("d")) {
            FireGunInPosition("third");
        } else if (Input.GetKeyDown(KeyCode.LeftControl)) {
            DisplayShieldStatus();
        }
    }

    private void DisplayShieldStatus() {
        Debug.unityLogger.Log(shield.Status());
    }

    private void FireGunInPosition(string v) {
        guns[v].Trigger();
        heatsink.SinkHeat(guns[v].HeatTransfer());
    }

	private GunBehavior makeGun(string gunName, float fireRate, float heat) {
		GunBehavior gun = gameObject.AddComponent<GunBehavior>();
		gun.weaponName = gunName;
		gun.fireRate = fireRate;
		gun.heat = heat;
		return gun;
	}

	private void makeHeatsink(float heatThreshold, float sinkRate) {
		HeatsinkBehavior heatsink = gameObject.AddComponent<HeatsinkBehavior> ();
		heatsink.heatThreshold = heatThreshold;
		heatsink.sinkRate = sinkRate;
    }
}
