using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WorldManager : MonoBehaviour
{
    public static WorldManager Instance;
    public Camera MainCamera;
    public Slider EnergySlider;
    public GameObject EndGameScreen;



    private void Awake()
    {
        Instance = this;
    }


    public void EndEnergyMoment()
    {
        Debug.Log("End energy");
        EndGameScreen.SetActive(true);
    }

    public static Vector3 WorldLookPoint => Instance.MainCamera.ScreenToWorldPoint(Input.mousePosition);
}
