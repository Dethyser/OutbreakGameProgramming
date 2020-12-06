using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeFloorSwitch : MonoBehaviour
{
    public bool switchedOn = false;
    public float duration;

    private void Update() {
        
        if(duration > 0.0f) {

            duration -= Time.deltaTime;
        }else if(switchedOn) {

            SwitchOff();
        }
    }

    public void SwitchOn(float duration) {

        this.duration = duration;
        switchedOn = true;
        transform.position = new Vector3(0,-5.0f,0);
    }

    void SwitchOff() {

        switchedOn = false;
        transform.position = new Vector3(0, -10.0f, 0);
    }
}
