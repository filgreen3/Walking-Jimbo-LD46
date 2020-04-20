using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunshot : GenericItem
{
    [SerializeField] private GameObject fire;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bulletShell;

    [SerializeField] private float force;
    [SerializeField] private Transform firePoint;



    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip fireSound;
    [SerializeField] private AudioClip outOfAmmoSound;




    public float Ammo = 3;

    public override void Action(PlayerArm arm)
    {
        if (Ammo > 0)
        {
            Ammo--;
            Shot();
        }
        else
        {
            audioSource.PlayOneShot(outOfAmmoSound);
        }
    }

    public void Shot()
    {

        audioSource.PlayOneShot(fireSound);
        Instantiate(bulletShell, transform.position + transform.up, Quaternion.identity).GetComponent<Rigidbody2D>().AddForce(transform.up * force / 10f);
        Instantiate(bullet, firePoint.position, Quaternion.identity).GetComponent<Rigidbody2D>().AddForce((firePoint.position - transform.position).normalized * force);
        StartCoroutine(Attack());
    }
    IEnumerator Attack()
    {

        fire.SetActive(true);
        yield return new WaitForSeconds(.1f);
        fire.SetActive(false);


    }

}
