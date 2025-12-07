using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SnowBallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject snowball;

    public int snowballCounter = 1;
    public int level = 0;
    public readonly List<int> levelCounters = new() { 21, 20, 21, 19 };
    public readonly List<bool> timedBalls = new() { false, false, true, false };
    public readonly List<bool> blueBalls = new() { false, false, false, true };

    void Start()
    {
        Instantiate(snowball, new Vector3(-6.5f, -1f, -.5f), Quaternion.identity);
    }

    public void SpawnSnowball()
    {
        if (snowballCounter < levelCounters[level])
        {
            Instantiate(snowball, new Vector3(-6.5f, -1f, -.5f), Quaternion.identity);
            snowballCounter++;
        }
    }

    public void LevelUp()
    {
        level++;
        snowballCounter = 1;

        GameObject[] snowballs = GameObject.FindGameObjectsWithTag("Snowball");

        foreach (GameObject snowball in snowballs)
        {
            Destroy(snowball);
        }

        Instantiate(snowball, new Vector3(-6.5f, -1f, -.5f), Quaternion.identity);
    }
}
