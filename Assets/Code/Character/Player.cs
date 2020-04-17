using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    public virtual Vector3 LookPoint { get => WorldManager.WorldLookPoint; }
    public ArmIK Arm;


    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        Arm.targetObj.localPosition = Vector3.ClampMagnitude((LookPoint - Arm.transform.position), 5f);
    }
}
