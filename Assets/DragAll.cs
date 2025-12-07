using Unity.VisualScripting;
using UnityEngine;

public class DragAll : MonoBehaviour
{
    private Transform dragging = null;
    private Vector3 offset;

    private GameObject gameLogic;
    private SnowBallSpawner snowBallSpawner;

    void Start()
    {
        gameLogic = GameObject.FindWithTag("GameLogic");
        snowBallSpawner = gameLogic.GetComponent<SnowBallSpawner>();
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit && hit.collider.CompareTag("Snowball"))
            {
                if (snowBallSpawner.timedBalls[snowBallSpawner.level])
                {
                    Snowball snowballComponent = hit.collider.GetComponent<Snowball>();
                    if (snowballComponent != null && snowballComponent.snowballTimer >= 2f)
                    {
                        dragging = null;
                    }
                    else
                    {
                        dragging = hit.transform;
                        offset = dragging.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    }
                }
                else
                {
                    dragging = hit.transform;
                    offset = dragging.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
            }
        } else if (Input.GetMouseButtonUp(0))
        {
            dragging = null;
        }

        if (dragging != null)
        {
            dragging.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }
}
