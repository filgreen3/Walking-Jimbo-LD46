using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    [Header("Arm Setting")]
    public PlayerArm Arm;
    public float ArmForce;
    public LayerMask HitMask;

    private Rigidbody2D armTarget;



    public virtual Vector3 LookPoint { get => WorldManager.WorldLookPoint; }



    private void Start()
    {
        armTarget = Arm.targetObj.GetComponent<Rigidbody2D>();
    }

    protected override bool ExtraCoditionToRotate => Arm.TakedObject == null;

    private RaycastHit2D[] hit = new RaycastHit2D[1];

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        var armTr = Arm.Transf;
        var maxDist = 5f;


        if (Physics2D.RaycastNonAlloc(armTr.position, LookPoint - armTr.position, hit, 5f, HitMask) > 0)
        {
            maxDist = hit[0].distance;
        }

        var t = Vector2.ClampMagnitude(LookPoint - armTr.position, maxDist) + (Vector2)(armTr.position);
        t = (t - armTarget.position) * ArmForce;
        armTarget.velocity = t * t.magnitude;


        //if (!rotating && Rig.velocity.magnitude < 1f && Mathf.Abs(armTarget.position.x - Transf.position.x) > 1f)
        //    StartCoroutine(TurnAround(armTarget.position.x - Transf.position.x > 0 ? 180 : 0));
    }
}
