using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.relativeVelocity.magnitude > 10f)
        {
            Destroy(gameObject, 0.01f);
        }
    }
}
