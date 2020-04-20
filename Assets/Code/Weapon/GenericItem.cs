using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericItem : MonoBehaviour
{
    public virtual void Action(PlayerArm arm) { }
    public void Drop()
    {
        gameObject.layer = 8;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Joint2D>().enabled = false;
    }
}
