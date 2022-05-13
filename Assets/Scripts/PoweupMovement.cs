using UnityEngine;

public class PoweupMovement : ForwardMovement
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TrackPlayer();
    }

    public void TrackPlayer()
    {
        if (player != null)
        {
            if (transform.position.x > player.transform.position.x)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetX, player.transform.position.y, transform.position.z), speed);
            }
            else
            {
                MoveForward();
            }
        }
        else
        {
            MoveForward();
        }
    }
}
