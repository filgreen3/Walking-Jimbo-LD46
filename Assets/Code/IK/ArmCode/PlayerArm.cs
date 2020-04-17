using UnityEngine;

public class PlayerArm : ArmIK
{



    public Transform Clac1;
    public Transform Clac2;

    [Header("Take Setting")]
    public Transform RigTakeObj;
    public Rigidbody2D TakedObject;

    public LayerMask TakeMask;

    public Vector3 prevPoint;

    protected override void Update()
    {
        base.Update();

        if (Input.GetMouseButtonDown(0))
        {
            Clac1.Rotate(Vector3.forward, -230);
            Clac2.Rotate(Vector3.forward, -130);


            Clac1.Rotate(Vector3.forward, 180);
            Clac2.Rotate(Vector3.forward, 180);


            var t = Physics2D.OverlapCircleAll(RigTakeObj.position, 1f, TakeMask);
            if (t.Length > 0)
            {
                TakedObject = t[0].gameObject.GetComponent<Rigidbody2D>();
                TakedObject.gravityScale = 0f;
            }
        }



        if (Input.GetMouseButtonUp(0))
        {
            Clac1.Rotate(Vector3.forward, -180);
            Clac2.Rotate(Vector3.forward, -180);

            Clac1.Rotate(Vector3.forward, 230);
            Clac2.Rotate(Vector3.forward, 130);


            if (TakedObject != null)
            {
                TakedObject.gravityScale = 1f;
                TakedObject.velocity = Vector3.ClampMagnitude((RigTakeObj.position - prevPoint) * 50f, 10f);
                TakedObject = null;
            }
        }



        if (TakedObject != null && Input.GetMouseButton(0))
        {
            TakedObject.MovePosition(RigTakeObj.position);

            if ((RigTakeObj.position - prevPoint).magnitude>0.1f)
                prevPoint = RigTakeObj.position;

        }




    }

}
