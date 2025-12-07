using UnityEngine;

public class Line : MonoBehaviour
{
    public GameObject line;

    private float snowballTimer = 0f;
    private bool snowballTouching = false;

    private SnowBallSpawner snowballSpawner;

    private void Start()
    {
        GameObject gameLogic = GameObject.FindWithTag("GameLogic");
        snowballSpawner = gameLogic.GetComponent<SnowBallSpawner>();
    }

    private void Update()
    {
        if (snowballTouching)
        {
            snowballTimer += Time.deltaTime;

            if (snowballTimer >= 5f)
            {
                Debug.Log("Level up");
                snowballSpawner.LevelUp();
                snowballTouching = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Snowball"))
        {
            snowballTouching = true;
            snowballTimer = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Snowball"))
        {
            snowballTouching = false;
            snowballTimer = 0f;
        }
    }
}
