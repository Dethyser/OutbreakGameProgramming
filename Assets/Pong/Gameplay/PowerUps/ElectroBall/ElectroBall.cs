using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroBall : MonoBehaviour {

    public int charges = 1;
    public int range = 2;
    public int hits = 3;

    public void ActivateEffect() {

        foreach (GameObject temp in GameObject.FindGameObjectsWithTag("Ball")) {

            temp.GetComponent<BallController>().ElectroBall(charges, range, hits);
        }
    }
}
