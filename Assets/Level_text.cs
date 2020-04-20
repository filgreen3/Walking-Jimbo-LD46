using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level_text : MonoBehaviour
{
    Elevator Elevator;
    bool end = false;
    public GameObject EndGameSquare;
    public Text txt;
    string story;
    public AudioClip sound;
    public AudioSource audio;
    void Start()
    {
        Elevator = GameObject.FindGameObjectWithTag("Elevator").GetComponent<Elevator>();
        GetComponent<TextMesh>().text = Elevator.Level.ToString();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            end = true;
            EndGameSquare.SetActive(true);
            txt = GameObject.Find("EndGameText").GetComponent<Text>();
            StartCoroutine("EndGame");
        }
    }
    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2f);

        story = "\n\nThe game was made in 72 hours\nfor Ludum Dare #46";
        txt.text = "";
        foreach (char c in story)
        {
            txt.text += c;
            audio.PlayOneShot(sound);
            audio.pitch = Random.Range(1, 2.1f);
            yield return new WaitForSeconds(0.025f);
        }
        yield return new WaitForSeconds(5f);


        story = "\n\nVisit our website for more stuff:\nkoro.games";
        txt.text = "";
        foreach (char c in story)
        {
            txt.text += c;
            audio.PlayOneShot(sound);
            audio.pitch = Random.Range(1, 2.1f);
            yield return new WaitForSeconds(0.025f);
        }
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(0);

    }
}
