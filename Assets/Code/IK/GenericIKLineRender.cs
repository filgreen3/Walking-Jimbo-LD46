using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericIKLineRender : MonoBehaviour
{
    public Transform target = null;
    [SerializeField] protected LineRenderer Bones = null;

    public float Weight;
    public float Lenght;

    public float zOffset;

    public virtual Vector3 IKTarget => target.position;


    protected virtual void FixedUpdate()
    {

        for (int i = Bones.positionCount - 1; i >= 0; i--)
        {
            Vector3 dir;
            Vector3 target;

            if (i < Bones.positionCount - 1)
            {
                target = Bones.GetPosition(i + 1);
            }
            else
            {
                target = IKTarget;
            }




            dir = target - Bones.GetPosition(i);
            dir.Normalize();

            var pos = target - dir * Lenght;
            pos.z = zOffset;
            Bones.SetPosition(i, pos);
        }
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(IKTarget, 0.2f);
    }
}
