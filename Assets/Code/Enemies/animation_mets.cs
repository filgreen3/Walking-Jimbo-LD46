using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation_mets : MonoBehaviour
{
    public Gunshot Gunshot;
    private void Start()
    {
        Gunshot = transform.Find("Enemy_Hand/Weapon_holder").GetChild(0).gameObject.GetComponent<Gunshot>();

        //GetComponent<Animator>().SetFloat("ASpeed", Random.Range(0.7f, 1.3f));
    }
    public void Rotate()
    {
        gameObject.transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
    public void Attack()
    {
        Gunshot.Shot();
    }

}
