using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmedCharacter : Character
{
    [SerializeField] protected Vector3 GunOffset;

    public virtual Vector3 LookPoint { get; protected set; }

    public Gun CharacterArm
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




    private Vector3 prevPoint;

    protected void OnGunChanged(Gun value)
    {
        foreach (var arm in Arms)
        {
            arm.target = value.transform;
        }
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        var pos = LookPoint - Transf.position;
        pos.z = 0;
        pos = Vector3.ClampMagnitude(pos, 3f);

        CharacterArm.Transf.localPosition = pos;

        if (Input.GetMouseButton(1))
        {
            DeltaAngle(pos);
        }
    }


    void DeltaAngle(Vector3 pos)
    {
        pos = pos - prevPoint;

        if (pos.magnitude > 0.1f)
        {
            var angle = (57.2f * Mathf.Atan2(pos.x, pos.y) - 90f);
            var angleBool = (Mathf.Abs(angle) > 90);

            CharacterArm.Transf.eulerAngles = Vector3.forward * (angle * (angleBool ? 1 : -1)) - Vector3.right * (angleBool ? 180 : 0);
        }
        prevPoint = CharacterArm.Transf.localPosition;
    }

    void AngleMove(Vector3 pos)
    {
        var angle = (57.2f * Mathf.Atan2(pos.x, pos.y) - 90f);
        var angleBool = (Mathf.Abs(angle) > 90);

        CharacterArm.Transf.eulerAngles = Vector3.forward * (angle * (angleBool ? 1 : -1)) - Vector3.right * (angleBool ? 180 : 0);
    }


}


