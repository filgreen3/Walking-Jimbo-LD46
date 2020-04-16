using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public static WorldManager Instance;
    public Camera MainCamera;

    private void Awake()
    {
        Instance = this;
    }

    public static Vector3 WorldLookPoint => Instance.MainCamera.ScreenToWorldPoint(Input.mousePosition);
}
