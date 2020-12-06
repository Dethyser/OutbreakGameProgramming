using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {

    public Text lifeText;
    public Text scoreText;
    public Text highscoreText;

    public int lifeCount = 3;
    public int currentScore = 0;

    public int activeBalls = 1;
    public GameObject ball;
    public float ballScale = 1.0f;
    public float ballSpeedMultiplier = 1.0f;

    private void Awake() {

        foreach (GameObject temp in GameObject.FindGameObjectsWithTag("PowerUp")) {

            Destroy(temp);
        }
        highscoreText.text = "Highscore: " + GameObject.Find("HighscoreManager").GetComponent<Highscore>().GetHighscore();
    }
    void Start() {

        UpdateScores();
    }

    public void AddPoints(int points) {

        currentScore += points;
        UpdateScores();
    }

    public void addLife() {

        lifeCount++;
        UpdateScores();
    }

    void removeLife() {

        lifeCount--;
        if (lifeCount <= 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            ballScale = 1.0f;
            ballSpeedMultiplier = 1.0f;
        }
        else {

            GameObject[] uselessPowerUps = GameObject.FindGameObjectsWithTag("PowerUp");

            for (int i = 0; i < uselessPowerUps.Length; i++) {

                Destroy(uselessPowerUps[i]);
            }

            GameObject newBall = Instantiate(ball, new Vector2(0, -3.5f), Quaternion.identity);
            newBall.name = "Ball";
            newBall.GetComponent<BallController>().StopAndResetBall();
            newBall.GetComponent<BallController>().scale = ballScale;
            newBall.GetComponent<BallController>().speedMultiplier = ballSpeedMultiplier;
        }
        UpdateScores();
    }

    public void addBall() {

        activeBalls++;
    }

    public void removeBall() {

        activeBalls--;
        if (activeBalls <= 0) {

            removeLife();
        }
    }

    void UpdateScores() {

        lifeText.text = "Lifes: " + lifeCount;
        scoreText.text = "Score: " + currentScore;
    }

    private void OnDestroy() {

        GameObject.Find("HighscoreManager").GetComponent<Highscore>().NewScore(currentScore);
    }
}
