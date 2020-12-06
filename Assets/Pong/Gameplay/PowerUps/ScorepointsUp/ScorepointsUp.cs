using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorepointsUp : MonoBehaviour {

    public int score = 500;

    public void ActivateEffect() {

        GameObject.Find("ScoreManager").GetComponent<ScoreManager>().AddPoints(score);
    }
}
