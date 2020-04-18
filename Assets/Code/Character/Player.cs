using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    [Header("Arm Setting")]
    public ArmIK Arm;
    public float ArmForce;
    public LayerMask HitMask;

    private Rigidbody2D armTarget;


    public virtual Vector3 LookPoint { get => WorldManager.WorldLookPoint; }



    private void Start()
    {
        armTarget = Arm.targetObj.GetComponent<Rigidbody2D>();
    }


    private RaycastHit2D[] hit = new RaycastHit2D[1];

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        var armTr = Arm.Transf;
        var target = LookPoint;

        if (Physics2D.RaycastNonAlloc(armTr.position, LookPoint - armTr.position, hit, 5f, HitMask) > 0)
        {
            target = hit[0].point;
        }

        var t = Vector2.ClampMagnitude(target - armTr.position, 5f) + (Vector2)(armTr.position);
        t = (t - armTarget.position) * ArmForce;
        armTarget.velocity = t * t.magnitude;
    }
}
