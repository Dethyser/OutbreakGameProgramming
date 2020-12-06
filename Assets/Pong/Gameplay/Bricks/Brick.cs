using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private BrickSpawner spawner;
    private PowerUpManager powerUpSpawner;

    private int xPosition;
    private int yPosition;

    bool isDestroyed = false;

    public Lightning lightningPrefab;

    public bool isInvisible = false;
    public float invisibleTime;

    public bool isPenetrating = false;
    public float penetratingDuration;

    public GameObject brickSprite;

    public Color brickColor;

    void Start() {

        powerUpSpawner = GameObject.Find("PowerUpManager").GetComponent<PowerUpManager>();
        switch (yPosition) {

            case 0:
                brickColor = new Color(1.0f, 0.0f, 1.0f);
                break;
            case 1:
                brickColor = Color.blue;
                break;
            case 2:
                brickColor = Color.green;
                break;
            case 3:
                brickColor = Color.yellow;
                break;
            case 4:
                brickColor = new Color(1.0f, 0.5f, 0.0f);
                break;
            default:
                brickColor = Color.red;
                break;

        }
        brickSprite.GetComponent<SpriteRenderer>().color = brickColor;
    }

    void Update() {

        if (invisibleTime > 0.0f) {
            invisibleTime -= Time.deltaTime;
        }
        else if (isInvisible) {

            isInvisible = false;
            CheckColor();
        }
        if (penetratingDuration > 0.0f) {
            penetratingDuration -= Time.deltaTime;
        }
        else if (isPenetrating) {

            isPenetrating = false;
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (isDestroyed) {

            return;
        }
        else {

            isDestroyed = true;
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().AddPoints(100);
            Destroy(gameObject);
        }
    }

    private void OnDestroy() {

        powerUpSpawner.SpawnPowerUp(gameObject.transform.position);
        spawner.OnBeforeBrickDestroyed(xPosition, yPosition);
    }

    public void SetBrickSpawner(BrickSpawner spawner)
    {
        this.spawner = spawner;
    }

    public void SetBrickOffset(int xPositon, int yPositon) {


        this.xPosition = xPositon;
        this.yPosition = yPositon;
    }
    void CheckColor() {

        if (isInvisible) {

            brickSprite.GetComponent<SpriteRenderer>().color = Color.clear;
        }
        else {

            brickSprite.GetComponent<SpriteRenderer>().color = brickColor;
        }
    }

    public void AoeIn(int range) {

        for (int x = -range; x <= range; x++) {

            for (int y = -range; y <= range; y++) {

                GameObject aoeVictim = GameObject.Find("Brick(" + (xPosition + x) + "|" + (yPosition + y) + ")");
                if (aoeVictim != null) {

                    aoeVictim.GetComponent<Brick>().AoeOut();
                }
            }
        }
    }

    public void AoeOut() {

        Destroy(gameObject);
    }

    public void ElectroIn(int range, int hits) {
        
            Lightning newLightning = Instantiate(lightningPrefab, transform.position, Quaternion.identity);
            newLightning.GoToTarget(range, (hits - 1), xPosition, yPosition);
    }

    public void ElectroOut(int range, int hits) {

        if(hits > 0) {

            ElectroIn(range, hits);
        }
        Destroy(gameObject);
    }

    public void BravoSixGoingDark(float invisibleTime) {

        this.invisibleTime = invisibleTime;
        isInvisible = true;
        CheckColor();
    }

    public void PacmanBite() {

        Destroy(gameObject);
    }

    public void GetPenetrated() {

        Destroy(gameObject);
    }

    public void PenetrationStart(float duration) {

        penetratingDuration = duration;
        isPenetrating = true;

        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    public void GetShot() {

        Destroy(gameObject);
    }
}
