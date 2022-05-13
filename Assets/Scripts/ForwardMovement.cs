using UnityEngine;

public class ForwardMovement : MonoBehaviour
{

    public float speed = 0.2f;
    public float targetX = -30;

    //Propell the object forward at the listed speed
    void FixedUpdate()
    {
        MoveForward();
    }

    public void MoveForward()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetX, transform.position.y, transform.position.z), speed);
    }
}
