using UnityEngine;

public class ScoreCollider : BaseCollider //INHERITANCE
{
    public EventChannelObject scoreEvent;

    // Start is called before the first frame update
    void Start()
    {
        noise = GetComponent<AudioSource>();
    }

    public override void OnTriggerEnter2D(Collider2D collision) //POLYMORPHISM
    {
        if (collision.gameObject.tag == "Player")
        {
            //Call the Score Event and play noise
            scoreEvent.RaiseEvent();
            noise.Play();
            Debug.Log("Score Collider Activated");
        }
    }
}
