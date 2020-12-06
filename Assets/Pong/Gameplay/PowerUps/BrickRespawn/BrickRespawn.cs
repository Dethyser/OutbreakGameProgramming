using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickRespawn : MonoBehaviour {

    public int respawmAmount = 0;

    public void ActivateEffect() {

        GameObject.Find("BrickSpawner").GetComponent<BrickSpawner>().RespawnBricks(respawmAmount);
    }
}
