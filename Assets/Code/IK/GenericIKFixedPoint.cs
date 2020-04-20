using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericIKFixedPoint : GenericSubTargetIKLineRender
{
    [ContextMenu("Update")]

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        Bones.SetPosition(0, transform.position);

        for (int i = 1; i < Bones.positionCount; i++)
            Bones.SetPosition(i, Bones.GetPosition(i - 1) + (Bones.GetPosition(i) - Bones.GetPosition(i - 1)).normalized * Lenght);
    }
}
