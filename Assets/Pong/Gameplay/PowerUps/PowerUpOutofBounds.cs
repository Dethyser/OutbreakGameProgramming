using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpOutofBounds : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Respawn")) {

            Destroy(gameObject);
        }
    }
}
