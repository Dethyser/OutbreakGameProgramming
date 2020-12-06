using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacman : MonoBehaviour {

    public int stepCount = 3;

    public void ActivateEffect() {

        GameObject.Find("BrickSpawner").GetComponent<BrickSpawner>().WakaWaka(stepCount);
    }
}
