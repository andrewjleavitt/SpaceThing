using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public EnemySpaceShip enemy;

    internal void SetupLevel() {
        enemy = new EnemySpaceShip();
        LayoutObject(enemy);
    }

    private void LayoutObject(EnemySpaceShip enemy) {
        Instantiate(enemy, new Vector3(9f, 0f, 0f), Quaternion.identity);
    }
}
