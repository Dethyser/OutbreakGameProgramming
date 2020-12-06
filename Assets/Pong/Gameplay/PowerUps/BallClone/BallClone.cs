using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallClone : MonoBehaviour
{
    public GameObject ball;

    public void ActivateEffect() {

        GameObject newBall = Instantiate(ball, new Vector2(0, -3.5f), Quaternion.identity);
        newBall.name = "Ball";
        newBall.GetComponent<BallController>().ClonedBall();
    }
}
