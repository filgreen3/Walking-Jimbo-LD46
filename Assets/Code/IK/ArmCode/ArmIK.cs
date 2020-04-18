using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmIK : GenericIK
{

    public Transform Transf;
    public override Vector2 IKTarget => targetObj.position;


    private void Start()
    {
        Transf = transform;
    }

    protected override void Update()
    {
        base.Update();


        Bones[0].position = transform.position;

        for (int i = 1; i < Bones.Count; i++)
            Bones[i].position = Bones[i - 1].endPoint;

    }

}
