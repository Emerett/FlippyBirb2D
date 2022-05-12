using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyCleanup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
