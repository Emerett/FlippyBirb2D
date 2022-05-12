using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMovement : MonoBehaviour
{

    public float speed = 0.2f;
    public float targetX = -30;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Propell the object forward at the listed speed
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetX, transform.position.y, transform.position.z), speed);
    }
}
