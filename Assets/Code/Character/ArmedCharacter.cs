using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmedCharacter : Character
{

    public virtual Vector3 LookPoint { get; protected set; }

    public Gun CharacterGun
    {
        get
        {
            return myGun;
        }
        set
        {
            myGun = value;
            OnGunChanged(myGun);
        }
    }
    private Gun myGun;

    protected void OnGunChanged(Gun value)
    {
        foreach (var arm in Arms)
        {
            arm.ArmTarget = value.transform;
        }
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        var pos = LookPoint - Transf.position;
        pos.z = 0;
        pos = Vector3.ClampMagnitude(pos, 1.5f);



        CharacterGun.Transf.localPosition = pos;

        var angle = (57.2f * Mathf.Atan2(pos.x, pos.y) - 90f);
        var angleBool = (Mathf.Abs(angle) > 90);

        CharacterGun.Transf.eulerAngles = Vector3.forward * (angle * (angleBool ? 1 : -1)) - Vector3.right * (angleBool ? 180 : 0);

    }


}


