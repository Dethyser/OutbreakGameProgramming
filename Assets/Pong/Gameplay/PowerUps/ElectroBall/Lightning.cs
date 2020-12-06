using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {

    int range;
    int hits;
    int xPosition;
    int yPosition;
    public float waitTime = 0.25f;
    bool thunder = false;

    void Update() {

        if(thunder) {

            waitTime -= Time.deltaTime;
        }
        if(waitTime <= 0.0f) {

            List<GameObject> electroVictims = new List<GameObject>();
            for (int x = -range; x <= range; x++) {

                for (int y = -range; y <= range; y++) {

                    GameObject newElectroVictim = GameObject.Find("Brick(" + (xPosition + x) + "|" + (xPosition + y) + ")");
                    if (newElectroVictim != null && x != 0 && y != 0) {

                        electroVictims.Add(newElectroVictim);
                    }
                }
            }
            if (electroVictims.Count == 0 || hits == 0) {

                DestroyLightning();
            } else {

                GameObject electroVictim = electroVictims[Random.Range(0, electroVictims.Count)];
                transform.position = electroVictim.transform.position;
                electroVictim.GetComponent<Brick>().ElectroOut(range,hits);
            }
            thunder = false;
            waitTime = 1.0f;
            
        }
    }

    public void GoToTarget(int range, int hits, int xPosition, int yPosition) {

        this.range = range;
        this.hits = hits;
        this.xPosition = xPosition;
        this.yPosition = yPosition;
        thunder = true;
        gameObject.name = "Lightning";
    }

    void DestroyLightning() {

        gameObject.name = "LastLightning";
        bool stillLighting = true;
        do {
            GameObject lightning = GameObject.Find("Lighting");
            if (lightning != null) {

                Destroy(lightning);
            }
            else {

                stillLighting = false;
            }

        } while (stillLighting);

        Destroy(gameObject);
    }
}
