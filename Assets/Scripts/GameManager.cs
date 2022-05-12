using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score;
    public bool isGameActive;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    public GameObject player;
    public GameObject window;
    public List<GameObject> obstacles;
    public List<GameObject> powerups;

    public EventChannelObject gameOverEvent;
    private AudioSource noise;

    private float spawnInterval = 2;
    private float powerupInterval = 20;

    private void Start()
    {
        noise = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += StartGame;
        gameOverEvent.onEventRaised += GameOver;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= StartGame;
        gameOverEvent.onEventRaised -= GameOver;
    }

    // Starts the game
    public void StartGame(Scene scene, LoadSceneMode mode)
    {
        scoreText.gameObject.SetActive(true);
        player.SetActive(true);
        isGameActive = true;
        Physics2D.gravity.Normalize();
        StartCoroutine(SpawnRandomObstacle());
        StartCoroutine(SpawnRandomPowerups());
    }

    //Triggers the Game Over state
    public void GameOver()
    {
        noise.Play();
        player.SetActive(false);
        isGameActive = false;
        Physics2D.gravity = new Vector2(0, 0);
        gameOverText.gameObject.SetActive(true);
    }

    //Obtain a random obstacle assigned to the array and spawn it in the world
    IEnumerator SpawnRandomObstacle()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnInterval);
            int obstacleIndex = Random.Range(0, obstacles.Count);
            Vector3 spawnPos = new Vector3(transform.position.x, obstacles[obstacleIndex].transform.position.y, obstacles[obstacleIndex].transform.position.z);
            Instantiate(obstacles[obstacleIndex], spawnPos, obstacles[obstacleIndex].transform.rotation);

            //speeds up the game by increasing the rate of obstacles and powerups until obstacles are spawning 1 sec apart and powerups are spawning every 20 sec
            if (spawnInterval > 1.0f)
            {
                spawnInterval -= 0.01f;
                powerupInterval -= 0.1f;
            }
        }
    }

    //Obtain a random powerup assigned to the array and spawn it in the world
    IEnumerator SpawnRandomPowerups()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(powerupInterval);
            int randomIndex = Random.Range(0, powerups.Count);
            Vector3 spawnPos = new Vector3(transform.position.x, powerups[randomIndex].transform.position.y, powerups[randomIndex].transform.position.z);
            Instantiate(powerups[randomIndex], spawnPos, powerups[randomIndex].transform.rotation);
            Instantiate(window, window.transform.position, window.transform.rotation);
        }
    }
}
