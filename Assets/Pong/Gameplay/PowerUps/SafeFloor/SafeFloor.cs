using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeFloor : MonoBehaviour {

    public float duration = 10.0f;

    public void ActivateEffect() {

        GameObject.Find("Wall_BOTTOM").GetComponent<SafeFloorSwitch>().SwitchOn(duration);
    }
}
