using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoeDamage : MonoBehaviour {

    public float aoeDuration;
    public int aoeRange;

    public void ActivateEffect() {

        foreach(GameObject temp in GameObject.FindGameObjectsWithTag("Ball")) {

            temp.GetComponent<BallController>().AoeDamage(aoeDuration, aoeRange);
        }
    }
}
