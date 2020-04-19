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

    Transform Player;
    public SpriteRenderer Indicator;

    public bool Active = false;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        //Indicator = gameObject.transform.Find("Indicator").gameObject.GetComponent<SpriteRenderer>();

    }
    private void Update()
    {
        if (Active)
        {
            Indicator.color = new Color(0.149f, 0.858f, 0.579f);
            if (Player.position.x < transform.position.x + 1
            && Player.position.x > transform.position.x - 1)
            {
                Active = false;
                StartCoroutine("Elevate");
            }
        }
    }

    IEnumerator Elevate()
    {
        Player.parent = gameObject.transform;
        Player.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        float elapsedTime = 0;
        float waitTime = 3f;
        Vector2 currentPos = transform.position;
        Vector2 Gotoposition = new Vector2(transform.position.x, transform.position.y + 34);
        while (elapsedTime < waitTime)
        {
            transform.position = Vector3.Lerp(currentPos, Gotoposition, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;


            yield return null;
        }
        transform.position = Gotoposition;
        Player.parent = null;
        Player.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        Indicator.color = new Color(0.98f, 0.34f, 0.16f);
        yield return null;

    }
    public void SetActive()
    {
        Active = true;
    }



}

