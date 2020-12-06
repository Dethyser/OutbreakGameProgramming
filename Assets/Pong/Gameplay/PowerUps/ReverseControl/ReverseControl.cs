using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseControl : MonoBehaviour {

    public float duration = 10.0f;

    public void ActivateEffect() {

        GameObject.Find("Player").GetComponent<RacketController>().StartReverse(duration);
    }
}
