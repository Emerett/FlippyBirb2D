using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCollider : MonoBehaviour
{
    private GameManager manager;
    private AudioSource noise;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        noise = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Get the player's score, increment it, then announce it
            noise.Play();
            manager.score++;
            manager.scoreText.text = "Score: " + manager.score;
        }
    }
}
