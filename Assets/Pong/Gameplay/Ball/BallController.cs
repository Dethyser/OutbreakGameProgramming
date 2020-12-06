using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector3 initialPosition;
    private bool started = false;

    public float initialSpeed = 5f;
    [Range(0, 90f)]
    public float initialMaxAngle = 45f;

    public float racketDeviationScale = 3f;
    public float wallDeviationScale = 3f;

    public float collisionSpeedMultiplier = 1.0f;

    //---------------------------

    public GameObject ballSprite;
    public GameObject ballBorder;

    public float aoeCurrent;
    public int aoeRange;
    public bool aoeActivated = false;

    public float scale = 1.0f;

    public float speedMultiplier = 1.0f;

    public int electroCharges = 0;
    public int electroRange;
    public int electroHits;

    public float invisibleEffectTime;
    public bool isInvisible = false;

    public float penetrationDuration;
    public bool isPenetrating = false;

    public bool isSniping = false;



    private void Awake()
    {
        initialPosition = transform.position;

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        if (Input.GetButtonDown("Jump") && !started)
        {
            StartBall();
        }

        if (aoeCurrent > 0.0f) {

            aoeCurrent -= Time.deltaTime;
        }else if(aoeActivated) {

            aoeActivated = false;
        }

        if (invisibleEffectTime > 0.0f) {

            invisibleEffectTime -= Time.deltaTime;
            if ((invisibleEffectTime % 1.25f) < 1.0f) {

                isInvisible = true;
            }else{
                isInvisible = false;
            }
        }

        if (penetrationDuration > 0.0f) {

            penetrationDuration -= Time.deltaTime;
        }
        else if (isPenetrating) {

            isPenetrating = false;
        }
        CheckColor();
    }

    public void StartBall()
    {
        NewScale();
        rb.velocity = GetInitialDirection() * initialSpeed * speedMultiplier;
        started = true;
    }

    public void StopAndResetBall()
    {
        rb.velocity = Vector2.zero;
        transform.position = initialPosition;
        started = false;
        GameObject.Find("ScoreManager").GetComponent<ScoreManager>().addBall();
    }

    private Vector2 GetInitialDirection()
    {

        // Manuel's solution
        Vector2 newVector = new Vector2(
            x: Random.Range(-Mathf.Tan(initialMaxAngle * Mathf.PI / 180), Mathf.Tan(initialMaxAngle * Mathf.PI / 180)),
            y: 1f
            );

        return newVector.normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.CompareTag("Brick")) {
            if (aoeActivated) {

                collision.gameObject.GetComponent<Brick>().AoeIn(aoeRange);
            }
            if (electroCharges > 0) {

                collision.gameObject.GetComponent<Brick>().ElectroIn(electroRange, electroHits);
                electroCharges--;
            }
        }else 
        if (collision.gameObject.CompareTag("Wall")) {
            if (isSniping) {

                GameObject temp = GameObject.FindGameObjectWithTag("Brick");
                if(temp != null) {

                    float magnitudeStrength = rb.velocity.magnitude;
                    rb.velocity = Vector3.zero;
                    rb.velocity = ((Vector3)(temp.transform.position - transform.position)).normalized * magnitudeStrength;
                    isSniping = false;
                }

            }
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            // calculate deviation factor
            float deviationFactor = transform.position.x - collision.gameObject.transform.position.x;

            // normalize deviationFactor
            deviationFactor /= (collision.collider.bounds.size.x + collision.otherCollider.bounds.size.x) / 2f;

            // copy existing velocity vector
            Vector2 newVelocity = rb.velocity;

            // modify y-component of velocity vector
            newVelocity.x += deviationFactor * racketDeviationScale;

            // normalize resulting vector
            newVelocity.Normalize();

            // "restore" initial velocity
            newVelocity *= (rb.velocity.magnitude * collisionSpeedMultiplier);

            // set new velocity
            rb.velocity = newVelocity;
        }
        else
        {
            if (Mathf.Abs(rb.velocity.normalized.y) < 0.1f)
            {
                // calculate deviation factor
                float deviationFactor = collision.gameObject.transform.position.y - transform.position.y;

                // normalize deviationFactor
                deviationFactor /= (collision.collider.bounds.size.y + collision.otherCollider.bounds.size.y) / 2f;

                // help a little in the center of the field
                if (Mathf.Abs(deviationFactor) < 0.1f)
                {
                    deviationFactor = 0.5f * Mathf.Sign(deviationFactor);
                }

                // copy existing velocity vector
                Vector2 newVelocity = rb.velocity.normalized;

                // modify x-component of velocity vector
                newVelocity.y = deviationFactor * wallDeviationScale;

                // normalize resulting vector
                newVelocity.Normalize();

                // "restore" initial velocity
                newVelocity *= rb.velocity.magnitude;

                // set new velocity
                rb.velocity = newVelocity;
            }

            rb.velocity = rb.velocity.normalized * initialSpeed * speedMultiplier;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Respawn")) {

            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().removeBall();
            Destroy(gameObject);
            
        }else if (collision.gameObject.CompareTag("Brick")) {

            collision.gameObject.GetComponent<Brick>().GetPenetrated();
        }else if (collision.gameObject.CompareTag("Rocket")) {

        }
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;

        Gizmos.matrix = transform.localToWorldMatrix;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.zero, Vector3.right * rb.velocity.x);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(Vector3.zero, Vector3.up * rb.velocity.y);

        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(Vector3.zero, rb.velocity);
    }

    void CheckColor() {

        if (isInvisible) {

            ballSprite.GetComponent<SpriteRenderer>().color = Color.clear;
        }
        else {
            if ((aoeActivated) && (electroCharges <= 0) && (!isPenetrating)) {

                ballSprite.GetComponent<SpriteRenderer>().color = Color.yellow;
            }
            else if ((!aoeActivated) && (electroCharges > 0) && (!isPenetrating)) {

                ballSprite.GetComponent<SpriteRenderer>().color = Color.blue;
            }
            else if ((aoeActivated) && (electroCharges > 0) && (!isPenetrating)) {

                ballSprite.GetComponent<SpriteRenderer>().color = Color.green;
            }
            else if ((!aoeActivated) && (electroCharges <= 0) && (isPenetrating)) {

                ballSprite.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else if ((aoeActivated) && (electroCharges <= 0) && (isPenetrating)) {

                ballSprite.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.5f, 0.0f);
            }
            else if ((!aoeActivated) && (electroCharges > 0) && (isPenetrating)) {

                ballSprite.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 1.0f);
            }
            else if ((aoeActivated) && (electroCharges > 0) && (isPenetrating)) {

                ballSprite.GetComponent<SpriteRenderer>().color = new Color(0.545f, 0.271f, 0.075f);
            } else {

                ballSprite.GetComponent<SpriteRenderer>().color = Color.white;
            }
            ballBorder.GetComponent<SpriteRenderer>().enabled = isSniping;
            if (isSniping) {
                if (ballSprite.GetComponent<SpriteRenderer>().color != Color.white) {

                ballBorder.GetComponent<SpriteRenderer>().color = new Color((1.0f - ballSprite.GetComponent<SpriteRenderer>().color.r), (1.0f - ballSprite.GetComponent<SpriteRenderer>().color.g), (1.0f - ballSprite.GetComponent<SpriteRenderer>().color.b));
                }else{

                ballBorder.GetComponent<SpriteRenderer>().color = new Color(0.235f,0.314f,0.157f);
                } 
            }
            
        }
    }

    public void AoeDamage(float aoeDuration, int aoeRange) {

        aoeCurrent = aoeDuration;
        this.aoeRange = aoeRange;
        aoeActivated = true;
    }

    public void ClonedBall() {
        StopAndResetBall();
        StartBall();
    }

    public void NewScale() {

        if (scale < 0.25f) {

            scale = 0.25f;
        }
        transform.localScale = new Vector2(scale, scale);
    }

    public void NewSpeed() {

        if (speedMultiplier < 0.75f) {

            speedMultiplier = 0.75f;
        }

        rb.velocity = rb.velocity.normalized * initialSpeed * speedMultiplier;
    }

    public void ElectroBall(int charges, int range, int hits) {


        electroCharges = charges;
        electroRange = range;
        electroHits = hits;
    }

    public void InvisibleBall(float invisibleTime) {

        this.invisibleEffectTime = invisibleTime;
    }

    public void Penetration(float penetrationDuration) {

        this.penetrationDuration = penetrationDuration;
        isPenetrating = true;
    }

    public void SnipingBall() {

        isSniping = true;
    }
}
