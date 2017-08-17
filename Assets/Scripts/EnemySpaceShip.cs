using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaceShip : MonoBehaviour {

    public int hp = 0;
    public int level = 0;

    public Dictionary<string, GunBehavior> guns = new Dictionary<string, GunBehavior>();

    GunBehavior slowPeaShooter = new GunBehavior("Slow Pea Shooter", 3f, 0.1f);

    void Start() {
        guns.Add("first", slowPeaShooter);
    }

    void Update() {
        getAiAction();
    }

    void getAiAction() {
        FireGunInPosition("first");
    }

    private void FireGunInPosition(string v) {
        guns[v].Trigger();
        guns[v].HeatTransfer();
    }
}
