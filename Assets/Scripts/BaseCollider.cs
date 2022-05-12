using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollider : MonoBehaviour
{
    public AudioSource noise;

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
