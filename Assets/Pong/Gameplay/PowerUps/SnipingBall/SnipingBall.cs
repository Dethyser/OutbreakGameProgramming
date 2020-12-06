using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnipingBall : MonoBehaviour {

    public void ActivateEffect() {

        foreach (GameObject temp in GameObject.FindGameObjectsWithTag("Ball")) {

            temp.GetComponent<BallController>().SnipingBall();
        }
    }
}
