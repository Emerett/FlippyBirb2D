using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float scale = 3.0f;
    private float speed = 5;
    private float idealPos = -10;
    private float leftBound = -25;
    private int shieldDuration = 10;
    public bool isShielded = false;
    public GameObject shield;
    public InputAction flipInput;

    public EventChannelObject gameOverEvent;
    private SpriteRenderer birb;
    private Rigidbody2D rb;
    private AudioSource noise;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        birb = GetComponent<SpriteRenderer>();
        noise = GetComponent<AudioSource>();
        flipInput.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        //Flip gravity when pressing the Jump key
        if (flipInput.WasPressedThisFrame())
        {
            noise.Play();
            Physics2D.gravity = new Vector2(0, scale);
            rb.AddForce(new Vector2(0,scale), ForceMode2D.Impulse);
            scale = -scale;
            birb.flipX = !birb.flipX;     
        }

        //If the player moves too far out of bounds, disable them. Otherwise, move the player back to the ideal position if they get dislodged by obstacles
        if (transform.position.x < leftBound)
        {
            gameOverEvent.RaiseEvent();
            gameObject.SetActive(false);
        }

        else if (transform.position.x < idealPos || transform.position.x > idealPos)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3 (idealPos, transform.position.y, transform.position.z), step);
        }

        //If the isShielded bool is activated by collision, start the Shields Up coroutine
        if (isShielded)
        {
            StartCoroutine(ShieldsUp(shieldDuration));
        }
    }

    //Set up a temporary shield to protect the player
    IEnumerator ShieldsUp(int duration)
    {
        shield.SetActive(true);
        yield return new WaitForSeconds(duration);
        isShielded = false;
        shield.SetActive(false);
    }


}
