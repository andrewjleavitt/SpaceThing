using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaceShip : MonoBehaviour {

    public int hp = 0;
    public int level = 0;
    public int attack = 0;
    public int armor = 0;
    public float fireRate = 0.0f;

    private bool triggerGun = false;
    private float nextFire = 0;

    void Start() {

    }

    void Update() {
        aiAction();
        // fireGun();
    }

    void aiAction() {
       triggerGun = true;
    }

    void fireGun() {
        if (triggerGun && Time.time > nextFire) {
        nextFire = Time.time + fireRate;
            Debug.unityLogger.Log("INFO", "Enemy Gun Triggered");
            triggerGun = false;
        }
    }
}
