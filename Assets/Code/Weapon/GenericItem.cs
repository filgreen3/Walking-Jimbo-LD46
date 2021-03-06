﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericItem : MonoBehaviour
{
    public virtual void Action(PlayerArm arm) { }
    public virtual void Drop()
    {
        gameObject.layer = 8;
        transform.SetParent(null);
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Joint2D>().enabled = false;
        GetComponent<Collider2D>().isTrigger = false;
    }
}
