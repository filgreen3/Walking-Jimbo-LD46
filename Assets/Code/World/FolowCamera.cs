using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowCamera : MonoBehaviour
{

    private float lerpTime = .05f;
    public Transform objectToFolow;
    Elevator elevator;
    private void Start()
    {
        elevator = GameObject.Find("Elevator").GetComponent<Elevator>();
    }
    void Update()
    {
        if (elevator.Level < 1)
        {
            transform.position = Vector3.Lerp(transform.position, objectToFolow.position, lerpTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, objectToFolow.position, lerpTime);
            transform.position = new Vector3(0, transform.position.y, -10);
        }
    }


}