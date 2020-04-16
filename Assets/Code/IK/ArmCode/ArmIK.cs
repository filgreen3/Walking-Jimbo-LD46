using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKArm : GenericIKLineRender
{

    [SerializeField] private Camera cameraMain;

    public override Vector3 IKTarget => cameraMain.ScreenToWorldPoint(Input.mousePosition);

    protected override void Update()
    {
        base.Update();

        Bones.SetPosition(0, transform.position);

        for (int i = 1; i < Bones.positionCount; i++)
            Bones.SetPosition(i, Bones.GetPosition(i - 1) + (Bones.GetPosition(i) - Bones.GetPosition(i - 1)).normalized * Lenght);
    }

}
