using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Author: Alexandrov Alexander Alexandrovich
Date: 25/10/2019

Script that implement death of player character
*/
public class DeathTrigger : MonoBehaviour {

    private GameController gameController;

    void Start() {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("game_controller");
        if (gameControllerObject != null) {
            gameController = gameControllerObject.GetComponent<GameController>();
        } else {
            Debug.Log("Cannot find 'GameController' script!");
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            Destroy(other.gameObject);
            gameController.GameOver();
        }
    }
    
}
