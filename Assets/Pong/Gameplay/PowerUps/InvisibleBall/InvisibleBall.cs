using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleBall : MonoBehaviour {

    public float invisibleTime = 15.0f;

    public void ActivateEffect() {

        foreach (GameObject temp in GameObject.FindGameObjectsWithTag("Ball")) {

            temp.GetComponent<BallController>().InvisibleBall(invisibleTime);
        }
    }
}
