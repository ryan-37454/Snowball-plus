using Unity.VisualScripting;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    public Sprite blueBall;

    [SerializeField] private GameObject snowball;
    [SerializeField] private Rigidbody2D rigidBody2d;
    [SerializeField] private CircleCollider2D circleCollider2d;

    public bool held = false;
    public bool used = false;
    public Vector2 mousePos;
    public float snowballTimer = 0f;
    private bool snowballTimerOn = false;

    private GameObject gameLogic;
    private SnowBallSpawner snowBallSpawner;

    void Start()
    {
        gameLogic = GameObject.FindWithTag("GameLogic");
        snowBallSpawner = gameLogic.GetComponent<SnowBallSpawner>();
        if (snowBallSpawner.level == 2)
        {
            snowball.GetComponent<SpriteRenderer>().sprite = blueBall;
        }
    }

    void Update()
    {
        // mouse position
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (used) return;

        if (snowballTimerOn) snowballTimer += Time.deltaTime;

        if (!held)
        {
            if (Input.GetMouseButton(0) && Physics2D.OverlapPoint(mousePos) == snowball.GetComponent<Collider2D>())
            {
                // snowball held
                circleCollider2d.isTrigger = true;
                rigidBody2d.bodyType = RigidbodyType2D.Dynamic;
                held = true;

                if (snowBallSpawner.timedBalls[snowBallSpawner.level])
                {
                    snowballTimerOn = true;
                }
            }
        }
        else
        {
            if (!Input.GetMouseButton(0) || (snowBallSpawner.timedBalls[snowBallSpawner.level] && snowballTimer >= 2))
            {
                if (snowBallSpawner.timedBalls[snowBallSpawner.level])
                {
                    snowballTimer = snowballTimer + 2;
                }
                // snowball dropped
                circleCollider2d.isTrigger = false;
                rigidBody2d.gravityScale = 1;
                snowBallSpawner.SpawnSnowball();
                used = true;
            }
        }
    }
}
