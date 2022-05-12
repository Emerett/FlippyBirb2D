using UnityEngine;

public class ShieldCollider : BaseCollider //INHERITANCE
{ 
    // Start is called before the first frame update
    void Start()
    {
        noise = GetComponent<AudioSource>();
    }

    public override void OnTriggerEnter2D(Collider2D collision) //POLYMORPHISM
    {
        //If this collided with the player, set the player's isShielded bool to true and destroy this object
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().isShielded = true;
            noise.Play();
            Debug.Log("Shield Powerup Activated");
            Destroy(gameObject);
        }
    }
}
