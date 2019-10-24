using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

/*
Author: Alexandrov Alexander Alexandrovich
Date: 25/10/2019

Script that implement game controller
*/
public class GameController : MonoBehaviour {

    public int coinsCount = 35;

    public Text scoreText;
    public Text gameOverText;
    public Text restartText;

    private int score;
    private bool gameOver;

    // Start is called before the first frame update
    void Start() {
        score = 0;
        gameOver = false;
        restartText.text = "";
        gameOverText.text = "";
        UpdateScore();
    }

    // Update is called once per frame
    void Update() {
        if (gameOver) {
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void AddScore(int newScoreValue) {
        score += newScoreValue;
        UpdateScore();
        if (score >= coinsCount) {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null) {
                Destroy(playerObject);
                GameOver();
            }

        }        
    }

    void UpdateScore() {
        scoreText.text = "Coins: " + score;
    }

    public void GameOver() {
        gameOverText.text = "Game Over!";
        restartText.text = "Press 'R' for Restart";
        gameOver = true;
    }
}
