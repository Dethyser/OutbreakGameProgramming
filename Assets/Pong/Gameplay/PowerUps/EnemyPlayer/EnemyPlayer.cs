using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayer : MonoBehaviour {

    public GameObject paddle;
    public void ActivateEffect() {
        if(GameObject.Find("Enemy") != null) {

            return;
        }
        GameObject enemy = Instantiate(paddle, new Vector2(0,-1), Quaternion.identity);
        enemy.name = "Enemy";
        enemy.GetComponent<RacketController>().SetAI();
    }
}
