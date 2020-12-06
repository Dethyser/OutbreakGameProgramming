using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackhole : MonoBehaviour {

    public GameObject blackhole;

    public void ActivateEffect() {
        Vector2 blackholePosition;
        do {
            blackholePosition = new Vector2(Random.Range(-8.0f, 8.0f), Random.Range(-4.5f, 4.5f));
        } while (HasSpace(blackholePosition));
        Instantiate(blackhole, blackholePosition, Quaternion.identity);
    }

    bool HasSpace(Vector2 blackholePosition) {

        foreach(GameObject temp in GameObject.FindGameObjectsWithTag("Ball")) {

            Vector2 distance = new Vector2(blackholePosition.x - temp.transform.position.x, blackholePosition.y - temp.transform.position.y);
            Vector2 distanceSpawn = new Vector2(blackholePosition.x - 0, blackholePosition.y + 3.5f);

            if ((distance.magnitude <= 2.0f) || (distanceSpawn.magnitude <= 2.0f)) {

                return true;
            }
        }

        return false;
    }
}
