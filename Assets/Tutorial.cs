using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    bool D = false;
    bool A = false;
    bool W = false;
    bool S = false;
    bool E = false;
    int timer=0;
    bool canpress=false;
    public TextMesh txt;
    string story;

    void Awake()
    {
        txt = txt.GetComponent<TextMesh>();
        story = txt.text;
        txt.text = "";
    }

    IEnumerator PlayText()
    {
        canpress = false;
        txt.text = "";
        foreach (char c in story)
        {
            txt.text += c;
            yield return new WaitForSeconds(0.025f);
        }
        canpress = true;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 100) timer++;
        else
        {
            if (timer == 100)
            {
                timer++;
                story = "Ok! It's works.\nNow use D to go right";
                StartCoroutine("PlayText");
            }
            else
            {
                if (canpress&&Input.GetKeyDown(KeyCode.D) && !D && !A && !W && !S)
                {
                    story = "Now use A to go left";
                    StartCoroutine("PlayText");
                    D = true;
                }
                if (canpress&&Input.GetKeyDown(KeyCode.A) && D && !A && !W && !S)
                {
                    story = "Now use W to go up";
                    StartCoroutine("PlayText");
                    A = true;
                }
                if (canpress&&Input.GetKeyDown(KeyCode.W) && D && A && !W && !S)
                {
                    story = "Now use S to go down";
                    StartCoroutine("PlayText");
                    W = true;
                }
                if (canpress&&Input.GetKeyDown(KeyCode.S) && D && A && W && !S)
                {
                    story = "Now take that energy can";
                    StartCoroutine("PlayText");
                    S = true;
                }

            }
        } 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name== "Battery"&& canpress && D && A && W && S)
        {
            story = "Now put it down";
            StartCoroutine("PlayText");
        }
    }    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name== "Battery"&& canpress && D && A && W && S)
        {
            story = "Now take that energy can";
            StartCoroutine("PlayText");
        }
    }
}

