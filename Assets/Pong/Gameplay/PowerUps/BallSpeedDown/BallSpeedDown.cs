using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpeedDown : MonoBehaviour {

    public void ActivateEffect() {

        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");

        for (int i = 0; i < balls.Length; i++) {

            balls[i].GetComponent<BallController>().speedMultiplier -= 0.25f;
            balls[i].GetComponent<BallController>().NewSpeed();
        }

        GameObject.Find("ScoreManager").GetComponent<ScoreManager>().ballSpeedMultiplier -= 0.25f;
    }
}
