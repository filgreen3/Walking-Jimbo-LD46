using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;


public class WallLever : Lever
{
    public Transform Transf;
    public Rigidbody2D Rig;


    [SerializeField] public float minY;
    [SerializeField] public float maxY;

    public override float Value => (Transf.localPosition.y - minY) / maxY;

    public bool Active;


    void Update()
    {
        if (Active)
        {
            Transf.localPosition = Transf.localPosition.x * Vector3.right +
            Mathf.Clamp(Transf.localPosition.y, minY, maxY) * Vector3.up +
            Transf.localPosition.z * Vector3.forward;
            Transf.eulerAngles = Vector3.zero;
            Rig.velocity = Vector3.ClampMagnitude(Rig.velocity, 1f);

            if ((1 - Value) > 0.9f)
            {
                OnLeverTurnOn.Invoke();
                Active = false;
                Rig.gameObject.layer = 2;

            }
        }
        else
        {
            var levvalue = Transf.localPosition;
            levvalue.y = minY;
            Transf.localPosition = levvalue;
        }


    }

}
