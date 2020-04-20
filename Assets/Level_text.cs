using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_text : MonoBehaviour
{
    Elevator Elevator;
    void Start()
    {
        Elevator = GameObject.FindGameObjectWithTag("Elevator").GetComponent<Elevator>();
        GetComponent<TextMesh>().text = Elevator.Level.ToString();
    }
}
