using UnityEngine;

public class PlayerArm : ArmIK
{

    public Transform Clac1;
    public Transform Clac2;

    protected override void Update()
    {
        base.Update();

        if (Input.GetMouseButtonDown(0))
        {
            Clac1.Rotate(Vector3.forward, -230);
            Clac2.Rotate(Vector3.forward, -130);


            Clac1.Rotate(Vector3.forward, 180);
            Clac2.Rotate(Vector3.forward, 180);

        }
        if (Input.GetMouseButtonUp(0))
        {
            Clac1.Rotate(Vector3.forward, -180);
            Clac2.Rotate(Vector3.forward, -180);

            Clac1.Rotate(Vector3.forward, 230);
            Clac2.Rotate(Vector3.forward, 130);


        }


    }

}
