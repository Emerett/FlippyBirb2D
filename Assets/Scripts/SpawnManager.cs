using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject[] powerups;

    private float startDelay = 2;
    private float spawnInterval = 2;
    private float powerupDelay = 10;
    private float powerupInterval = 30;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomObstacle", startDelay, spawnInterval);
        InvokeRepeating("SpawnRandomPowerups", powerupDelay, powerupInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Obtain a random obstacle assigned to the array and spawn it in the world
    void SpawnRandomObstacle()
    {
        int obstacleIndex = Random.Range(0, obstacles.Length);
        Vector3 spawnPos = new Vector3 (transform.position.x, obstacles[obstacleIndex].transform.position.y, obstacles[obstacleIndex].transform.position.z);
        Instantiate(obstacles[obstacleIndex], spawnPos, obstacles[obstacleIndex].transform.rotation);
        
        //speeds up the game by increasing the rate of obstacles and powerups until obstacles are spawning 1 sec apart and powerups are spawning every 20 sec
        if (spawnInterval > 1.0f)
        {
            spawnInterval -= 0.01f;
            powerupInterval -= 0.1f;
        }
    }

    //Obtain a random powerup assigned to the array and spawn it in the world
    void SpawnRandomPowerups()
    { 
        int randomIndex = Random.Range(0, powerups.Length);
        Vector3 spawnPos = new Vector3(transform.position.x, powerups[randomIndex].transform.position.y, powerups[randomIndex].transform.position.z);
        Instantiate(powerups[randomIndex], spawnPos, powerups[randomIndex].transform.rotation);
    }
}
