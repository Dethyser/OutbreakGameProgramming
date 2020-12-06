using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackholeDespawn : MonoBehaviour
{
    public float blackholeDuration = 5.0f;

    void Update()
    {
        blackholeDuration -= Time.deltaTime;
        if(blackholeDuration <= 0.0f) {

            Destroy(gameObject);
        }
    }
}
