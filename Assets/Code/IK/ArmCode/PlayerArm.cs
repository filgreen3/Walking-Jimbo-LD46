using UnityEngine;

public class PlayerArm : ArmIK
{


    public Transform Clac1;
    public Transform Clac2;

    [Header("Take Setting")]
    public Transform RigTakeObj;
    public Rigidbody2D TakedObject;
    public Rigidbody2D ArmTarget;

    public LayerMask TakeMask;

    public float Force;

    public Joint2D Connector;




    public const float maxMass = 1f;



    public override Vector2 IKTarget => (TakedObject != null && TakedObject.mass > maxMass) ? TakedObject.position : (Vector2)targetObj.position;


    protected override void FixedUpdate()
    {
        base.FixedUpdate();



    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            TakeItem();

        if (Input.GetMouseButtonUp(0))
            DropItem();

        if (TakedObject != null && Input.GetMouseButton(0))
        {

            if (TakedObject.mass > maxMass)
                TakedObject.AddForce(Vector2.ClampMagnitude((Vector2)targetObj.position - TakedObject.position, 1f) * Force);
            else
            {
                TakedObject.velocity = ((Vector2)RigTakeObj.position - TakedObject.position);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            TakedObject?.GetComponent<GenericItem>()?.Action(this);
            TakedObject.velocity = Vector3.zero;
        }


    }
    public int savedLayer;

    public virtual void TakeItem()
    {


        var t = Physics2D.OverlapCircleAll(RigTakeObj.position, .5f, TakeMask);
        if (t.Length > 0)
        {

            TakedObject = t[0].gameObject.GetComponent<Rigidbody2D>();
            TakedObject.velocity = Vector3.zero;

            if (TakedObject.mass > maxMass)
            {
                Connector.enabled = true;
                Connector.connectedBody = TakedObject;
            }
            else
            {
                TakedObject.freezeRotation = true;
                TakedObject.gravityScale = 0f;
                TakedObject.transform.SetParent(RigTakeObj);
                savedLayer = TakedObject.gameObject.layer;
                TakedObject.gameObject.layer = 13;

            }
        }

        if (TakedObject == null) return;

        Clac1.Rotate(Vector3.forward, -230);
        Clac2.Rotate(Vector3.forward, -130);


        Clac1.Rotate(Vector3.forward, 180);
        Clac2.Rotate(Vector3.forward, 180);

    }


    public virtual void DropItem()
    {
        if (TakedObject == null) return;

        Clac1.Rotate(Vector3.forward, -180);
        Clac2.Rotate(Vector3.forward, -180);

        Clac1.Rotate(Vector3.forward, 230);
        Clac2.Rotate(Vector3.forward, 130);


        if (TakedObject != null)
        {
            TakedObject.gravityScale = 1f;
            if (TakedObject.mass <= maxMass)
                TakedObject.transform.SetParent(null);

            Connector.enabled = false;
            Connector.connectedBody = null;
            TakedObject.freezeRotation = false;
            TakedObject.gameObject.layer = savedLayer;



            TakedObject = null;
        }
    }
}
