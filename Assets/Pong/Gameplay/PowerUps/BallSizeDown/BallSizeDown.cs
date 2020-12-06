using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSizeDown : MonoBehaviour {

    public void ActivateEffect() {

        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");

        for (int i = 0; i < balls.Length; i++) {

            balls[i].GetComponent<BallController>().scale -= 0.25f;
            balls[i].GetComponent<BallController>().NewScale();
        }

        GameObject.Find("ScoreManager").GetComponent<ScoreManager>().ballScale -= 0.25f;
    }
}
