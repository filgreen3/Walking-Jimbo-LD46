using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour
{
    AudioSource audio;
    public AudioClip clip;
    public Image SOUNDER;
    public Text Text;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        Text.text = "x "+ PlayerPrefs.GetInt("Kills").ToString();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }   
    public void Exit()
    {
        Application.Quit();
    }    

    public void Difficulty(int i)
    {
        PlayerPrefs.SetInt("Difficulty", i);
        audio.PlayOneShot(clip);
    }   
    public void SoundOnOff()
    {
        Camera.main.GetComponent<AudioListener>().enabled = !Camera.main.GetComponent<AudioListener>().enabled;
        if (Camera.main.GetComponent<AudioListener>().enabled) SOUNDER.color = new Color(0.9803922f, 0.3411765f, 0.1529412f);
        else SOUNDER.color = new Color(0.75f, 0.75f, 0.75f);
    }



}
