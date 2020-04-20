using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class WorldManager : MonoBehaviour
{
    public static WorldManager Instance;
    public Camera MainCamera;
    public Slider EnergySlider;
    public GameObject EndGameScreen;
    public AudioSource WorldAudioSource;



    private void Awake()
    {
        Instance = this;
        WorldAudioSource = GetComponent<AudioSource>();

    }


    public void EndEnergyMoment()
    {
        Debug.Log("End energy");
        EndGameScreen.SetActive(true);
    }

    public static Vector3 WorldLookPoint => Instance.MainCamera.ScreenToWorldPoint(Input.mousePosition);
}
