using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class DamageConsume : MonoBehaviour
{
    public float MaxVelocityConsume;
    public UnityEvent OnGetDamage = new UnityEvent();

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.relativeVelocity.magnitude > MaxVelocityConsume)
        {
            OnGetDamage.Invoke();
        }
    }
}
