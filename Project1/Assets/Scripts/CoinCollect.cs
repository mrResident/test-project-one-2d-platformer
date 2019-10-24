﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
Author: Alexandrov Alexander Alexandrovich
Date: 25/10/2019

Script that implement collect of coins by player's character
*/

public class CoinCollect : MonoBehaviour {

    private GameController gameController;

    void Start() {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("game_controller");
        if (gameControllerObject != null) {
            gameController = gameControllerObject.GetComponent<GameController>();
        } else {
            Debug.Log("Cannot find 'GameController' script!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            gameController.AddScore(1);
            Destroy(gameObject);
        }
    }
    
}
