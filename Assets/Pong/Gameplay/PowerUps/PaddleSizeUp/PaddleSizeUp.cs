using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleSizeUp : MonoBehaviour {

    public void ActivateEffect() {

        GameObject paddle = GameObject.Find("Player");

        paddle.GetComponent<RacketController>().scale += 0.25f;
        paddle.GetComponent<RacketController>().NewScale();
    }
}
