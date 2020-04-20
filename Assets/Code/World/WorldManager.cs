using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class WorldManager : MonoBehaviour
{
    public static WorldManager Instance;
    public Camera MainCamera;
    public Slider EnergySlider;
    public GameObject EndGameScreen;
    public AudioSource WorldAudioSource;
    public Image SOUNDER;
    public int kills = 0;
    public Elevator Elevator;


    private void Awake()
    {
        Instance = this;
        WorldAudioSource = GetComponent<AudioSource>();
        Time.timeScale = 1;

    }


    public void EndEnergyMoment()
    {
        Debug.Log("End energy");
        if (Elevator.Level<0)EndGameScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void SoundOnOff()
    {
        Camera.main.GetComponent<AudioListener>().enabled = !Camera.main.GetComponent<AudioListener>().enabled;
        if (Camera.main.GetComponent<AudioListener>().enabled) SOUNDER.color = new Color(0.9803922f, 0.3411765f, 0.1529412f);
        else SOUNDER.color = new Color(0.75f, 0.75f, 0.75f);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }    
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public static Vector3 WorldLookPoint => Instance.MainCamera.ScreenToWorldPoint(Input.mousePosition);
}
