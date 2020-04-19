using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_default : MonoBehaviour
{
    public GameObject Door1;
    public GameObject Door2;
    public bool touched = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer != 9)
        {
            if (!touched)
            {
                touched = true;
                if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.x < 2f && collision.gameObject.GetComponent<Rigidbody2D>().velocity.x > -2)
                {

                    GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                    GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    GetComponent<BoxCollider2D>().enabled = false;

                    Door1.SetActive(false);
                    Door2.SetActive(true);
                }
                else 
                { 
                    GetComponent<BoxCollider2D>().isTrigger = false;
                    GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                }
            }
        }
    }

}
