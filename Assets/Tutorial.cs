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
    public Camera camera;
    bool dead = false;

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


    IEnumerator Dead()
    {
        Time.timeScale = 0.5f;
        float elapsedTime = 0;
        float waitTime = .8f;
        Vector3 currentPos = camera.transform.position;
        Vector3 Gotoposition = new Vector3(Enemy.gameObject.transform.position.x, Enemy.gameObject.transform.position.y+3,-10);
        while (elapsedTime < waitTime)
        {
            camera.transform.position = Vector3.Lerp(currentPos, Gotoposition, (elapsedTime / waitTime));
            camera.orthographicSize = Mathf.Lerp(8, 6, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;


            yield return null;
        }
        camera.transform.position = Gotoposition;

        Time.timeScale = 1f;
        elapsedTime = 0;
        waitTime = 1f;
        while (elapsedTime < waitTime)
        {
            camera.orthographicSize = Mathf.Lerp(6, 10, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;


            yield return null;
        }
        camera.orthographicSize =10;
        Destroy(gameObject);

    }
    void Update()
    {
        if (Enemy.dead&&!dead)
        {
            Destroy(txt.gameObject);
            StartCoroutine("Dead");
            dead = true;
        }
        if (timer < 100) timer++;
        else
        {
            if (timer == 100)
            {
                timer++;
                story = "Ok! It works.\nNow use W to get up";
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
                    story = "Now use S to sit down";
                    StartCoroutine("PlayText");
                    D = true;
                }
                if (canpress&&Input.GetKeyDown(KeyCode.S) && D && A && W && !S)
                {
                    story = "Use E to activate\nyour hand";
                    StartCoroutine("PlayText");
                    S = true;
                }                
                if (canpress&&Input.GetKeyDown(KeyCode.E) && D && A && W && S&&!E)
                {
                    story = "Using your hand you lose energy\nTake battery \v with L MOUSE\nand replace it with R MOUSE";
                    StartCoroutine("PlayText");
                    E = true;
                }
                if (canpress&&Input.GetMouseButtonDown(1) && D && A && W && S&&E)
                {
                    story = "Now lift that box over yourself\nBe careful with the lamp";
                    StartCoroutine("PlayText");
                    E = true;
                }

            }
        } 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name== "Box"&& canpress && D && A && W && S && E)
        {
            story = "Now put it down";
            StartCoroutine("PlayText");
        }
    }    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name== "Box" && canpress && D && A && W && S && E)
        {
            story = "Now lift that box\nover yourself";
            StartCoroutine("PlayText");
        }
    }
}

