using UnityEngine;

public class EmptyCleanup : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //Destroy empty parent objects if all children are destroyed
        if (gameObject.transform.childCount == 0)
        {
            Destroy(gameObject);
        }
    }
}
