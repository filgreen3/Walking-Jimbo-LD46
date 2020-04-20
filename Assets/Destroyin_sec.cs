using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyin_sec : MonoBehaviour
{
    public float sec=1;
    void Start()
    {
        StartCoroutine("Destroyin");
    }

    IEnumerator Destroyin()
    {
        yield return new WaitForSeconds(sec);
        Destroy(gameObject);
    }
}
