using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowCamera : MonoBehaviour
{

    private Vector3 Offset;
    [SerializeField] private float mul = default;

    [SerializeField] private float downBorder = 7;
    [SerializeField] private float upBorder = 20;

    private float lerpTime=.05f;

    public static Vector3 zeroPoint = Vector3.zero;

    public Transform objectToFolow;
    Elevator elevator;
    private void Start()
    {
        elevator = GameObject.Find("Elevator").GetComponent<Elevator>();
    }
    void Update()
    {

        /*var pos = Vector3.Lerp(transform.position, objectToFolow.position + Offset, 0.55f);
        pos.z = -10;
        pos.y = pos.y < downBorder ? downBorder : pos.y > upBorder ? upBorder : pos.y;
        transform.position = pos;*/
        if (elevator.Level < 0)
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