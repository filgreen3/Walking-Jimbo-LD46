﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {

        Destroy(gameObject, 0.01f);

    }
}
