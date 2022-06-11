using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    public float spawnRate = 4f;
    public int obstaclePoolSize = 5;
    public float obstacleYMin = -2f;
    public float obstacleYMax = 2f;

    private float timeSinceLastSpawn;
    private float spawnXPos = 0.1f;
    private int currentObstacle = 0;

    public GameObject obstaclesPrefab;

    private GameObject[] Obstacles;
    private Vector2 objectPoolPosition = new Vector2(-15, -25f);
    // Start is called before the first frame update
    void Start()
    {
        Obstacles = new GameObject[obstaclePoolSize];
        for(int i = 0; i < obstaclePoolSize; i++)
        {
            Obstacles[i] = (GameObject)Instantiate(obstaclesPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if(!GameController.instance.gameOver && timeSinceLastSpawn >= spawnRate)
        {
            timeSinceLastSpawn = 0;

            float spawnYPos = Random.Range(obstacleYMin, obstacleYMax);
            Obstacles[currentObstacle].transform.position = new Vector2(spawnXPos, spawnYPos);

            currentObstacle++;

            if(currentObstacle >= obstaclePoolSize) { currentObstacle = 0; }
        }
    }
}
