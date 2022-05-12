using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCollider : MonoBehaviour
{
    private AudioSource noise;

    // Start is called before the first frame update
    void Start()
    {
        noise = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If this collided with the player, set the player's isShielded bool to true and destroy this object
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 jumpLandingPoint = new Vector3(collision.transform.position.x + 20, collision.transform.position.y, collision.transform.position.z);
            collision.transform.position = jumpLandingPoint;
            noise.Play();
            Destroy(gameObject);
        }
    }
}
