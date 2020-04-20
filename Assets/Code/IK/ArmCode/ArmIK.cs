using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmIK : GenericIKFixedPoint
{

    public Transform Transf;
    public override Vector3 IKTarget => target.position;


    private void Start()
    {
        Transf = transform;
    }



}
