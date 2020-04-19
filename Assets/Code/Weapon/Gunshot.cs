using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunshot : GenericItem
{
    [SerializeField] private GameObject fire;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float force;


    public override void Action(PlayerArm arm) => Shot();

    public void Shot()
    {
        StartCoroutine(Attack());
    }
    IEnumerator Attack()
    {
        Instantiate(bullet, transform.position + transform.right, Quaternion.identity).GetComponent<Rigidbody2D>().AddForce(transform.right * force);
        fire.SetActive(true);
        yield return new WaitForSeconds(.1f);
        fire.SetActive(false);


    }

}
