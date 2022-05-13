using UnityEngine;

public class HarmfulCollider : BaseCollider //INHERITANCE
{
    public EventChannelObject gameOverEvent;

    // Start is called before the first frame update
    void Start()
    {
        noise = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If this object collides with the player, raise the Game Over event
        if (collision.gameObject.CompareTag("Player"))
        {
            gameOverEvent.RaiseEvent();
        }
    }

    public override void OnTriggerEnter2D(Collider2D collision) //POLYMORPHISM
    {
        //If this object collides with a shield, destroy this object
        if (collision.gameObject.CompareTag("Shield"))
        {
            noise.Play();
            Debug.Log("Obstacle Destroyed");
            Destroy(gameObject);
        }
    }
}
