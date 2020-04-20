using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class DamageConsume : MonoBehaviour
{
    public float MaxVelocityConsume;
    public LayerMask HitMask;
    public UnityEvent OnGetDamage = new UnityEvent();

    void OnCollisionEnter2D(Collision2D col)
    {

        if (HitMask == (HitMask | (1 << col.gameObject.layer)) && col.relativeVelocity.magnitude > MaxVelocityConsume)
        {
            OnGetDamage.Invoke();
        }
    }
}
