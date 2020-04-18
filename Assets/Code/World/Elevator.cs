using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject[] Rroom;
    public GameObject[] RroomB;
    public GameObject[] Lroom;
    public GameObject[] LroomB;
    public GameObject[] Croom;


    public GameObject CurrentRRoom;
    public GameObject CurrentLRoom;
    public GameObject CurrentCRoom;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            
        }
    }
}
