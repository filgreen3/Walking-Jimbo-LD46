using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    public virtual Vector3 LookPoint { get => WorldManager.WorldLookPoint; }
    public ArmIK Arm;
    private Rigidbody2D armTarget;
    public float ArmForce;


    private void Start()
    {
        armTarget = Arm.targetObj.GetComponent<Rigidbody2D>();
    }




    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        var t = Vector2.ClampMagnitude(LookPoint - Arm.transform.position, 3f) + (Vector2)Arm.transform.position;
        t = (t - armTarget.position) * ArmForce;
        armTarget.AddForce(t * t.magnitude);
        Arm.targetObj.localPosition = Vector3.ClampMagnitude(Arm.targetObj.localPosition, 3f);
    }
}
