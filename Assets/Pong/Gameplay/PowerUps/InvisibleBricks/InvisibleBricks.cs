using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleBricks : MonoBehaviour {

    public float invisibleTime = 10.0f;
    public void ActivateEffect() {

        foreach (GameObject temp in GameObject.FindGameObjectsWithTag("Brick")) {

            temp.GetComponent<Brick>().BravoSixGoingDark(invisibleTime);
        }
    }
}
