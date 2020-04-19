using System.Collections;
using System.Collections.Generic;
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
    public Enemy_AI Enemy; 
    string story;
    public AudioClip sound;
    AudioSource audio;

    void Awake()
    {
        txt = txt.GetComponent<TextMesh>();
        audio = GetComponent<AudioSource>();
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
            audio.PlayOneShot(sound);
            audio.pitch = Random.Range(1, 2.1f);
            yield return new WaitForSeconds(0.025f);
        }
        canpress = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (Enemy.dead) Destroy(gameObject);
        if (timer < 100) timer++;
        else
        {
            if (timer == 100)
            {
                timer++;
                story = "Ok! It's works.\nNow use W to go up";
                StartCoroutine("PlayText");
            }
            else
            {
                if (canpress&&Input.GetKeyDown(KeyCode.W) && !W && !A && !D && !S)
                {
                    story = "Now use A to go left";
                    StartCoroutine("PlayText");
                    W = true;
                }
                if (canpress&&Input.GetKeyDown(KeyCode.A) && W && !A && !D && !S)
                {
                    story = "Now use D to go right";
                    StartCoroutine("PlayText");
                    A = true;
                }
                if (canpress&&Input.GetKeyDown(KeyCode.D) && W && A && !D && !S)
                {
                    story = "Now use S to go down";
                    StartCoroutine("PlayText");
                    D = true;
                }
                if (canpress&&Input.GetKeyDown(KeyCode.S) && D && A && W && !S)
                {
                    story = "Now pick up that energy can.\nUse E.\nBe careful with the lamp!";
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
            story = "Now lift that energy can\nover yourself";
            StartCoroutine("PlayText");
        }
    }
}

