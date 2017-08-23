﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    private LevelManager levelScript;

    void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        levelScript = GetComponentInChildren<LevelManager>();
        InitGame();
    }

    void InitGame() {
        levelScript.SetupLevel();
    }
}