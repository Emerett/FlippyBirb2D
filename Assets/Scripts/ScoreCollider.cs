using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCollider : BaseCollider
{
    private GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        noise = GetComponent<AudioSource>();
    }

    public override void OnTriggerEnter2D(Collider2D collision)
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
