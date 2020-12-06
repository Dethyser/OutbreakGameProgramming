using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 10.0f;
    public bool wantsToStart = false;
    public bool started = false;
     GameObject paddle;

    private void Update() {

        if (Input.GetKeyDown("w") || Input.GetKeyDown("up")) {

            wantsToStart = true;
        }
        bool couldStart = true;
        if(wantsToStart) {

            foreach(GameObject temp in GameObject.FindGameObjectsWithTag("Ball")) {

                if((transform.position - temp.transform.position).magnitude <= 1.25f) {

                    couldStart = false;
                }
            }
            if (couldStart) {

                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                started = true;
            }
        }
    }

    private void FixedUpdate() {
        if (!started) {

            transform.position = paddle.transform.position + Vector3.up;
        }
        else {
            float correction = 0.0f;
            foreach (GameObject temp in GameObject.FindGameObjectsWithTag("Ball")) {

                if ((transform.position.x - temp.transform.position.x) <= 1.0f) {

                    if(transform.position.x < temp.transform.position.x) {

                        correction = 1.0f; 
                    }else{

                        correction = -1.0f;
                    }
                }
            }
            transform.position = transform.position + Vector3.up * speed * Time.deltaTime + Vector3.right * correction * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Brick")) {

            Destroy(gameObject);
        }

    }

    public void SetPaddle(GameObject paddle) {

        this.paddle = paddle;
    }
}
