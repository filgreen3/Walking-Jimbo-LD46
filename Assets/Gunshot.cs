using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunshot : MonoBehaviour
{
    public GameObject fire;
    public GameObject bullet;
public void Shot()
    {
        StartCoroutine("Attack");
    }
    IEnumerator Attack()
    {
        fire.SetActive(true);
        yield return new WaitForSeconds( .1f);
        fire.SetActive(false);


    }

}
