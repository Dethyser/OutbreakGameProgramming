using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : MonoBehaviour {

    public void ActivateEffect() {

        GameObject.Find("ScoreManager").GetComponent<ScoreManager>().addLife();
    }
}
