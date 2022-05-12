using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoweupMovement : MonoBehaviour
{
    public float speed = 0.2f;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x > player.transform.position.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-30, player.transform.position.y, transform.position.z), speed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-30, transform.position.y, transform.position.z), speed);
        }
    }
}
