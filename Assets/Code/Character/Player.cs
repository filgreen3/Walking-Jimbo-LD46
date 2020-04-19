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

    private bool armActive = true;


    public virtual Vector3 LookPoint { get => WorldManager.WorldLookPoint; }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            armActive = !armActive;
    }


    private void Start()
    {
        armTarget = Arm.targetObj.GetComponent<Rigidbody2D>();
    }

    protected override bool ExtraCoditionToRotate => Arm.TakedObject == null || Arm.TakedObject.mass < 1f;



    private Vector3 prevVector = Vector3.zero;
    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        var armTr = Arm.Transf;

        if (armActive)
        {

            var maxDist = 5f;
            var ray = Physics2D.Raycast(armTr.position, LookPoint - armTr.position, 5f, HitMask);


            if (ray)
            {
                maxDist = ray.distance;
            }

            var t = Vector2.ClampMagnitude(LookPoint - armTr.position, maxDist) + (Vector2)(armTr.position);
            t = (t - armTarget.position) * ArmForce;

            armTarget.velocity = Vector2.ClampMagnitude(t * t.magnitude, 15f);

            prevVector = armTarget.transform.localPosition;

        }
        else
        {
            armTarget.transform.localPosition = prevVector;

        }
    }

}
