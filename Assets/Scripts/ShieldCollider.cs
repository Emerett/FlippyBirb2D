using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCollider : BaseCollider
{ 
    // Start is called before the first frame update
    void Start()
    {
        noise = GetComponent<AudioSource>();
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        //If this collided with the player, set the player's isShielded bool to true and destroy this object
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().isShielded = true;
            noise.Play();
            Destroy(gameObject);
        }
    }
}
