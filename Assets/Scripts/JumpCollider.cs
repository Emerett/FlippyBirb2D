using UnityEngine;

public class JumpCollider : BaseCollider //INHERITANCE
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
            Vector3 jumpLandingPoint = new Vector3(collision.transform.position.x + 15, collision.transform.position.y, collision.transform.position.z);
            collision.transform.position = jumpLandingPoint;
            noise.Play();
            Debug.Log("Jump Powerup Activated");
            Destroy(gameObject);
        }
    }
}
