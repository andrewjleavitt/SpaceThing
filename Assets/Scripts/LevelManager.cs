using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public EnemySpaceShip enemy;
    public PlayerSpaceShip player;

    public void SetupLevel() {
        LayoutScene();
    }

    private void LayoutScene() {
        Instantiate(enemy, new Vector3(9f, 0f, 0f), Quaternion.identity);
        Instantiate(player, new Vector3(-9f, 0f, 0f), Quaternion.identity);
    }
}
