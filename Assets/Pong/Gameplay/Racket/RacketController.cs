using UnityEngine;

public class RacketController : MonoBehaviour
{
    float input;
    public float movementSpeed = 5f;

    public string axisName;
    public bool aiControlled;
    public Transform aiMovementTarget; // default = null

    private Rigidbody2D rb; // default = null

    public float enemyLifeTime = 10.0f;

    public float scale = 1.0f;

    public float reverseMultiplier = 1.0f;
    public bool isReverse = false;
    public float reverseDuration;

    public GameObject rocketPrefab;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(reverseDuration > 0.0f) {

            reverseDuration -= Time.deltaTime;
        }else if (isReverse) {

            reverseDuration = 1.0f;
            isReverse = false;
        }
        WatchSpeed();
        if (aiControlled)
        {
            if (aiMovementTarget != null)
            {
                if(aiMovementTarget.position.y < transform.position.y) {

                    if (aiMovementTarget.position.x > transform.position.x) {

                        // move right
                        input = 0.2f;
                    }else{

                        // move left
                        input = -0.2f;
                    }
                }
                else {
                    if ((aiMovementTarget.position.x - 2.0f) > transform.position.x) {

                        // move right
                        input = 0.2f;
                    }else if((aiMovementTarget.position.x + 2.0f) < transform.position.x) {

                        // move left
                        input = -0.2f;
                    }else{

                        if (aiMovementTarget.position.x > transform.position.x) {

                            // move left
                            input = -0.2f;
                        }
                        else {

                            // move right
                            input = 0.2f;
                        }

                    }
                }
            } else
            {
                //GameObject targetObject = GameObject.Find("Ball");

                BallController ball = GameObject.FindObjectOfType<BallController>();

                if (ball != null)
                {
                    aiMovementTarget = ball.transform;
                } else
                {
                    Debug.LogError("AiMovementTarget has not been assigned!");
                }
            }

            if (enemyLifeTime > 0.0f) {

                enemyLifeTime -= Time.deltaTime;
            }
            else {

                Destroy(gameObject);
            }
        } else
        {
            input = Input.GetAxisRaw(axisName);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.right * input * movementSpeed * reverseMultiplier;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (aiControlled) {

            return;
        }
        switch (collision.gameObject.name) {

            case "AoeDamage(Clone)":
                collision.gameObject.GetComponent<AoeDamage>().ActivateEffect();
                break;
            case "BallClone(Clone)":
                collision.gameObject.GetComponent<BallClone>().ActivateEffect();
                break;
            case "BallSizeDown(Clone)":
                collision.gameObject.GetComponent<BallSizeDown>().ActivateEffect();
                break;
            case "BallSizeUp(Clone)":
                collision.gameObject.GetComponent<BallSizeUp>().ActivateEffect();
                break;
            case "BallSpeedDown(Clone)":
                collision.gameObject.GetComponent<BallSpeedDown>().ActivateEffect();
                break;
            case "BallSpeedUp(Clone)":
                collision.gameObject.GetComponent<BallSpeedUp>().ActivateEffect();
                break;
            case "Blackhole(Clone)":
                collision.gameObject.GetComponent<Blackhole>().ActivateEffect();
                break;
            case "BrickRespawn(Clone)":
                collision.gameObject.GetComponent<BrickRespawn>().ActivateEffect();
                break;
            case "ElectroBall(Clone)":
                collision.gameObject.GetComponent<ElectroBall>().ActivateEffect();
                break;
            case "EnemyPlayer(Clone)":
                collision.gameObject.GetComponent<EnemyPlayer>().ActivateEffect();
                break;
            case "ExtraLife(Clone)":
                collision.gameObject.GetComponent<ExtraLife>().ActivateEffect();
                break;
            case "InvisibleBall(Clone)":
                collision.gameObject.GetComponent<InvisibleBall>().ActivateEffect();
                break;
            case "InvisibleBricks(Clone)":
                collision.gameObject.GetComponent<InvisibleBricks>().ActivateEffect();
                break;
            case "Pacman(Clone)":
                collision.gameObject.GetComponent<Pacman>().ActivateEffect();
                break;
            case "PaddleSizeDown(Clone)":
                collision.gameObject.GetComponent<PaddleSizeDown>().ActivateEffect();
                break;
            case "PaddleSizeUp(Clone)":
                collision.gameObject.GetComponent<PaddleSizeUp>().ActivateEffect();
                break;
            case "PaddleSpeedDown(Clone)":
                collision.gameObject.GetComponent<PaddleSpeedDown>().ActivateEffect();
                break;
            case "PaddleSpeedUp(Clone)":
                collision.gameObject.GetComponent<PaddleSpeedUp>().ActivateEffect();
                break;
            case "Penetration(Clone)":
                collision.gameObject.GetComponent<Penetration>().ActivateEffect();
                break;
            case "ReverseControl(Clone)":
                collision.gameObject.GetComponent<ReverseControl>().ActivateEffect();
                break;
            case "Rockets(Clone)":
                collision.gameObject.GetComponent<Rockets>().ActivateEffect();
                break;
            case "SafeFloor(Clone)":
                collision.gameObject.GetComponent<SafeFloor>().ActivateEffect();
                break;
            case "ScorepointsUp(Clone)":
                collision.gameObject.GetComponent<ScorepointsUp>().ActivateEffect();
                break;
            case "SnipingBall(Clone)":
                collision.gameObject.GetComponent<SnipingBall>().ActivateEffect();
                break;
            case "Timefreeze(Clone)":
                collision.gameObject.GetComponent<Timefreeze>().ActivateEffect();
                break;
            default:
                break;
        }
        Destroy(collision.gameObject);
    }

    public void SetAI() {

        aiControlled = true;
    }

    public void NewScale() {

        if(scale < 0.25f) {

            scale = 0.25f;
        } else if (scale > 2.0f) {

            scale = 2.0f;
        }
        transform.localScale = new Vector2(scale, 1);
    }

    void WatchSpeed() {

        if(movementSpeed <= 3.0f) {

            movementSpeed = 3.0f;
        }
    }

    public void StartReverse(float duration) {

        reverseDuration = duration;
        isReverse = true;
        reverseMultiplier = -1.0f;
    }

    public void AddRocket() {
        if(GameObject.Find("Rocket") != null) {

            return;
        }
        GameObject rocket = Instantiate(rocketPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity, transform);
        rocket.name = "Rocket";
        rocket.GetComponent<Rocket>().SetPaddle(gameObject);
    }
}
