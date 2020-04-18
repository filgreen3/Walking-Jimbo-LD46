using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    bool pause = false;
    public GameObject pausego;
    public void Press()
    {
        if (!pause)
        {
            pausego.SetActive(true);
            pause = true;
            Time.timeScale = 0f;
        }
        else
        {
            pausego.SetActive(false);
            pause = false;
            Time.timeScale = 1f;
        }
    }

}
