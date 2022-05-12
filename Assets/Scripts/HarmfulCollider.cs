using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarmfulCollider : MonoBehaviour
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If this object collides with the player, destroy the player
        if (collision.gameObject.CompareTag("Player"))
        {
            manager.GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If this object collides with a shield, destroy this object
        if (collision.gameObject.CompareTag("Shield"))
        {
            noise.Play();
            Destroy(gameObject);
        }
    }
}
