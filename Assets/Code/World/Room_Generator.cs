using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Generator : MonoBehaviour
{
    Elevator Elevator;


    public void Generate()
    {
        GameObject Ltodestroy = Elevator.CurrentLRoom;
        GameObject Rtodestroy = Elevator.CurrentRRoom;
        GameObject Ctodestroy = Elevator.CurrentCRoom;

        int i = Random.Range(0, 1);

        if (i == 0)
        {

            Elevator.CurrentCRoom = Instantiate(Elevator.Croom[Random.Range(0, Elevator.Croom.Length)], new Vector2(0, transform.position.y+ 34), Quaternion.identity);
            Elevator.CurrentLRoom = Instantiate(Elevator.LroomB[Random.Range(0, Elevator.LroomB.Length)], new Vector2(-22.5f, transform.position.y + 34), Quaternion.identity);
            Elevator.CurrentRRoom = Instantiate(Elevator.Rroom[Random.Range(0, Elevator.Rroom.Length)], new Vector2(22.5f, transform.position.y + 34), Quaternion.identity);
        }
        else
        {
            Elevator.CurrentCRoom = Instantiate(Elevator.Croom[Random.Range(0, Elevator.Croom.Length)], new Vector2(0, transform.position.y + 34), Quaternion.identity);
            Elevator.CurrentLRoom = Instantiate(Elevator.Lroom[Random.Range(0, Elevator.Lroom.Length)], new Vector2(-22.5f, transform.position.y + 34), Quaternion.identity);
            Elevator.CurrentRRoom = Instantiate(Elevator.RroomB[Random.Range(0, Elevator.RroomB.Length)], new Vector2(22.5f, transform.position.y + 34), Quaternion.identity);
        }
        Destroy(Ltodestroy);
        Destroy(Rtodestroy);
        Destroy(Ctodestroy);
    }
    void Start()
    {
        Elevator = GameObject.FindGameObjectWithTag("Elevator").GetComponent<Elevator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Elevator")
            Generate();
    }
}
