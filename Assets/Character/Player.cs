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

    private bool armActive = false;


    [Header("EnergySetting")]
    public Battery PlayerBattery;

    [Range(0, 0.1f)]
    public float ArmEnergyConsume, MoveEnergyConsume;



    public virtual Vector3 LookPoint { get => WorldManager.WorldLookPoint; }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            armActive = !armActive;
    }


    private void Start()
    {
        armTarget = Arm.targetObj.GetComponent<Rigidbody2D>();
        prevVector = Arm.targetObj.localPosition;
    }

    protected override bool ExtraCoditionToRotate => Arm.TakedObject == null || Arm.TakedObject.mass < 1f;



    private Vector3 prevVector;

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
        UpdateEnergyConsume();
    }


    void UpdateEnergyConsume()
    {
        if (PlayerBattery == null) return;


        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            PlayerBattery.Energy -= MoveEnergyConsume / 60f;
        }
        if (armActive)
        {
            PlayerBattery.Energy -= ArmEnergyConsume / 60f;
        }

        if (PlayerBattery.Energy <= 0)
            WorldManager.Instance.EndEnergyMoment();
        WorldManager.Instance.EnergySlider.value = PlayerBattery.Energy;

    }


}
