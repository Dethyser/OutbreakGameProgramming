using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockets : MonoBehaviour {

    public void ActivateEffect() {

        GameObject.Find("Player").GetComponent<RacketController>().AddRocket();
    }
}
