using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakaWaka : MonoBehaviour {

    public GameObject[] targets;
    public Vector2[] nodes;
    public Vector2[] nodeDirections;
    public Vector2 startCoordinates;

    public float speed = 1f;
    public int currentDirection = 0;

    private void Update() {

        if (((Vector3)(nodes[currentDirection]) - transform.position).magnitude > 0.1f) {

            transform.position = transform.position + (Vector3)(nodeDirections[currentDirection] * speed * Time.deltaTime);
        }else{

            nodeDirections[currentDirection].y *= -1;
            startCoordinates += nodeDirections[currentDirection];
            nodeDirections[currentDirection].y *= -1;
            GameObject nextVictim = GameObject.Find("Brick(" + startCoordinates.x + "|" + startCoordinates.y + ")");
            if (nextVictim != null){

                nextVictim.GetComponent<Brick>().PacmanBite();
            }
            currentDirection++;
        }
        if(currentDirection == nodes.Length) {

            Destroy(gameObject);
        }
    }

    public void StartTheGame(Vector2[] nodes, Vector2[] nodeDirections, Vector2 startCoordinates) {

        this.nodes = nodes;
        this.nodeDirections = nodeDirections;
        this.startCoordinates = startCoordinates;
    }
}
