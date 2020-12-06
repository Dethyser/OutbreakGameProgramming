using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penetration : MonoBehaviour {

    public float duration = 5.0f;

    public void ActivateEffect() {

        foreach (GameObject temp in GameObject.FindGameObjectsWithTag("Brick")) {

            temp.GetComponent<Brick>().PenetrationStart(duration);
        }
        foreach (GameObject temp in GameObject.FindGameObjectsWithTag("Ball")) {

            temp.GetComponent<BallController>().Penetration(duration);
        }
    }
}
