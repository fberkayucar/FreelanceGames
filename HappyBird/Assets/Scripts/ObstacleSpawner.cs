using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject downObstacle;
    public GameObject upObstacle;
    public GameObject pointObstacle;
    private Vector2 upSpawnHeight;
    private Vector2 downSpawnHeight;
    private float spawnTime = 2f;
    public BirdControl birdControlScript;
    void Start()
    {
        birdControlScript = GameObject.Find("Bird").GetComponent<BirdControl>();
        InvokeRepeating("Spawner", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Spawner()
    {
        if (!birdControlScript.isGameOver)
        {
            int randomX = Random.Range(7, 12);
            upSpawnHeight = new Vector2(10, randomX);
            downSpawnHeight = new Vector2(10, randomX - 9);
            pointObstacle.transform.position = new Vector2(11, randomX - 4.5f);
            Instantiate(upObstacle, upSpawnHeight, Quaternion.identity);
            Instantiate(downObstacle, downSpawnHeight, Quaternion.identity);
            Instantiate(pointObstacle, pointObstacle.transform.position, Quaternion.identity);
        }
        
    }
}
