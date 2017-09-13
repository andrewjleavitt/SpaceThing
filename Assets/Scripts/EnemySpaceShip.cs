using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaceShip : MonoBehaviour {

    public int hp = 0;
    public int level = 0;

    public Dictionary<string, GunBehavior> guns = new Dictionary<string, GunBehavior>();

	private GunBehavior slowPeaShooter;
    private GunBehavior throwingStar;


    void Start() {
		slowPeaShooter = gameObject.AddComponent<GunBehavior>();
		slowPeaShooter.weaponName = "Slow Pea Shooter";
        slowPeaShooter.fireRate = 3.0f;
        slowPeaShooter.heat = 2.0f;

        throwingStar = gameObject.AddComponent<GunBehavior>();
        throwingStar.weaponName = "Throwing star";
        throwingStar.fireRate = 0.5f;
        throwingStar.heat = 2.0f;

        guns.Add("first", slowPeaShooter);
        guns.Add("second", throwingStar);
    }

    void Update() {
        //getAiAction();
    }

    void getAiAction() {
        FireGunInPosition("first");
        FireGunInPosition("second");
    }

    private void FireGunInPosition(string v) {
        guns[v].Trigger();
        guns[v].HeatTransfer();
    }
}
