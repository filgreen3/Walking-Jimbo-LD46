using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : GenericItem
{

    private void Start() => Transf = transform;
    public Transform Transf;

    public float Energy = 1;

    public override void Action(PlayerArm arm)
    {
        var t = Physics2D.OverlapCircleAll(transform.position, .5f);

        foreach (var item in t)
        {
            if (item.tag == "BattreyLock")
            {
                arm.DropItem();
                item.GetComponent<BatteryLock>().LoadBattery(this);
            }
        }
    }
}
