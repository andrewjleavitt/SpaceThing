using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceShip : MonoBehaviour {

    public int hp = 0;
    public int level = 0;
    public float attack = 0;
    public ArmorBehavior armor;
    public float heatThreshold = 0.0f;

    public ShieldBehavior shield;
    public Dictionary <string, GunBehavior> guns = new Dictionary<string, GunBehavior>();
    public HeatsinkBehavior heatsink;
    private float heat = 0.0f;

    void Start() {
        GunBehavior peaShooter = new GunBehavior("Pea Shooter", 0.3f, 0.1f);
        GunBehavior mallowGun = new GunBehavior("Mallow Gun", 1.0f, 1.0f);
        GunBehavior wristRocket = new GunBehavior("Wrist Rocket", 0.8f, 1.1f);

        shield = new ShieldBehavior("Mighty Shield", 10.0f, 0.5f);
        armor = new ArmorBehavior("Cardboard", 100.0f);

        guns.Add("first",peaShooter);
        guns.Add("second",mallowGun);
        guns.Add("third",wristRocket);
    }

    void Update () {
        GetUserAction();
        SinkHeat();
        RegenerateShields();
    }

    private void RegenerateShields() {
        shield.Recharge();
    }

    private void SinkHeat() {
        float sink = heatsink.Sink();

        if (sink == -1f) {
            return;
        }

        Mathf.Max(0, heat -= sink);
    }

    private bool IsOverheating() {
        return heat > heatThreshold;
    }

    private void GetUserAction() {
        if (IsOverheating()) {
            return;
        }

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
        guns[v].HeatTransfer();
    }
}
