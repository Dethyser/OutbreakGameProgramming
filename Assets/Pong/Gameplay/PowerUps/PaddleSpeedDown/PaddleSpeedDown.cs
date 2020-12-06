using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleSpeedDown : MonoBehaviour {

    public void ActivateEffect() {

        GameObject paddle = GameObject.Find("Player");

        paddle.GetComponent<RacketController>().movementSpeed -= 1.0f;
    }
}
