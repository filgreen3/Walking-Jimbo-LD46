using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmIK : GenericIKFixedPoint
{

    public Transform ArmTarget
    {
        get => (armTarget == null) ? target : armTarget;
        set => armTarget = value;
    }

    private Transform armTarget;
    public override Vector3 IKTarget => ArmTarget.position;

    protected override void Update()
    {
        base.Update();
        var pos = IKTarget;
        pos.z = 0;
        Bones.SetPosition(Bones.positionCount - 1, pos);
    }

}
