using UnityEngine;

public class DestroyOutofBounds : MonoBehaviour
{
    private float leftBound = -25;
    private float rightBound = 35;

    // Update is called once per frame
    void Update()
    {
        //If the object goes too far out of bounds, destroy it
        if (transform.position.x < leftBound || transform.position.x > rightBound)
        {
            Destroy(gameObject);
        }
    }
}
