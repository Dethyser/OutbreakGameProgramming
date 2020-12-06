using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrickSpawner : MonoBehaviour
{
    public Brick brickPrefab;

    public int columns = 1; // x-coordinate
    public int rows = 1;    // y-coordinate

    public float xOffset = 1f;
    public float yOffset = 1f;

    public List<Vector2> destroyedBricks;

    public GameObject pacmanPrefab;

    private void Start()
    {
        SpawnBricks();
    }

    public void OnBeforeBrickDestroyed(int xPosition, int yPosition)
    {
        destroyedBricks.Add(new Vector2(xPosition, yPosition));
        if (transform.childCount <= 1)
        {
            Debug.Log("END");
            LoadNextLevel();
        }
    }

    void LoadNextLevel()
    {
        // get current scene build index
        int buildIndex = SceneManager.GetActiveScene().buildIndex;

        // get target scene build index
        buildIndex++;

        // is target scene build index out of bounds?
        if (buildIndex >= SceneManager.sceneCountInBuildSettings)
        {
            buildIndex = 0;
        }

        // load target scene
        SceneManager.LoadScene(buildIndex);
    }

    void SpawnBricks()
    {
        Vector3 startPosition = transform.position - ((Vector3.right * xOffset * (columns - 1)) + (Vector3.down * yOffset * (rows - 1))) / 2f;

        Brick newBrick;

        for (int y = 0; y < rows; y++) // rows
        {
            for (int x = 0; x < columns; x++) // columns
            {
                newBrick = Instantiate(
                    original: brickPrefab,
                    position: startPosition + (Vector3.right * xOffset * x) + (Vector3.down * yOffset * y),
                    rotation: Quaternion.identity,
                    parent: transform
                    );

                newBrick.gameObject.name = $"Brick({x}|{y})";
                newBrick.SetBrickOffset(x, y);

                newBrick.SetBrickSpawner(this);
            }
        }
    }

    private void OnValidate()
    {
        columns = Mathf.Clamp(columns, 1, columns);
        rows = Mathf.Clamp(rows, 1, rows);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.matrix = transform.localToWorldMatrix; // draws gizmos in local space from here on

        Gizmos.color = Color.green;

        Vector3 startPosition = -((Vector3.right * xOffset * (columns - 1)) + (Vector3.down * yOffset * (rows - 1))) / 2f;

        for (int y = 0; y < rows; y++) // rows
        {
            for (int x = 0; x < columns; x++) // columns
            {
                Gizmos.DrawWireCube(
                    center: startPosition + (Vector3.right * xOffset * x) + (Vector3.down * yOffset * y),
                    size: new Vector3(1f, 0.5f, 0)
                    );
            }
        }
    }

    public void RespawnBricks(int amount) {

        if (amount == 0) {

            amount = Random.Range(1, destroyedBricks.Count);
        }
        while (amount > 0) {

            if (destroyedBricks.Count <= 0) {

                amount = 0;
            }
            Vector2 brickIndex = destroyedBricks[Random.Range(0, destroyedBricks.Count)];
            Vector3 newBrickPosition = transform.position - ((Vector3.right * xOffset * (columns - 1)) + (Vector3.down * yOffset * (rows - 1))) / 2f;
            Brick newBrick = Instantiate(brickPrefab, newBrickPosition + (Vector3.right * xOffset * brickIndex.x) + (Vector3.down * yOffset * brickIndex.y), Quaternion.identity, transform);
            newBrick.gameObject.name = $"Brick({brickIndex.x}|{brickIndex.y})";
            newBrick.GetComponent<Brick>().SetBrickOffset(Mathf.RoundToInt(brickIndex.x), Mathf.RoundToInt(brickIndex.y));

            newBrick.SetBrickSpawner(this);
            destroyedBricks.Remove(newBrickPosition);
            amount--;
        }
    }

    public void WakaWaka(int steps) {

        
        Vector2 pacmanIndex = destroyedBricks[Random.Range(0, destroyedBricks.Count)];
        Vector3 pacmanPosition = transform.position - ((Vector3.right * xOffset * (columns - 1)) + (Vector3.down * yOffset * (rows - 1))) / 2f;
        GameObject pacman = Instantiate(pacmanPrefab, pacmanPosition + (Vector3.right * xOffset * pacmanIndex.x) + (Vector3.down * yOffset * pacmanIndex.y), Quaternion.identity);

        Vector2[] nodes = new Vector2[steps];
        Vector2[] nodeDirections = new Vector2[steps];
        Vector2 lastDirection = new Vector2(0, 0);
        Vector2 lastPosition = pacman.transform.position;
        for (int i = 0; i < steps; i++) {

            Vector2[] directions = { new Vector2(0, 1), new Vector2(0, -1), new Vector2(1, 0), new Vector2(-1, 0) };

            Vector2 newDirection = directions[Random.Range(0, directions.Length)];
            if (newDirection == -lastDirection) {

                if (newDirection == -directions[0]) {

                    newDirection = directions[Random.Range(1, directions.Length)];
                }
                else if (newDirection == -directions[(directions.Length - 1)]) {

                    newDirection = directions[Random.Range(0, (directions.Length - 1))];
                }
                else {

                    newDirection = lastDirection;
                }
            }

            Vector2 newPosition = lastPosition + (Vector2.right * xOffset * newDirection.x) + (Vector2.down * yOffset * newDirection.y);
            nodes[i]  = newPosition;
            lastPosition = newPosition;
            lastDirection = newDirection;
            newDirection.y *= -1;
            nodeDirections[i] = newDirection;
        }

        pacman.GetComponent<WakaWaka>().StartTheGame(nodes, nodeDirections, pacmanIndex);
    }
}
