using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highscore : MonoBehaviour
{

    private static Highscore managerInstance;
    public int highestScore = 0;

    private void Awake() {

        DontDestroyOnLoad(this);

        if (managerInstance == null) {

            managerInstance = this;
        }
        else {

            Destroy(gameObject);
        }
    }

    public void NewScore(int score) {

        if(score > highestScore) {

            highestScore = score;
        }
    }

    public int GetHighscore() {

        return highestScore;
    }
}
