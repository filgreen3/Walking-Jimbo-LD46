using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    [SerializeField] protected Transform Transf;
    [SerializeField] protected ArmIK[] Arms = default;


    public LayerMask LegMask;
    public Rigidbody2D Rig;
    [SerializeField] private Vector2 characterOffest = default;
    public float CharacterOffestAddition = 0.5f;


    public Vector2 CharacterOffest => (characterOffest + Vector2.up * CharacterOffestAddition);

    [SerializeField] private float forceUp = default;
    [SerializeField] private float move = default;
    [SerializeField] private float rote = default;


    protected bool rotating;
    protected virtual bool ExtraCoditionToRotate => true;




    protected virtual void FixedUpdate()
    {

        var horiz = Input.GetAxis("Horizontal");

        if (horiz != 0)
        {
            Rig.AddForce(horiz * move * Vector2.right);

            if (!rotating && ExtraCoditionToRotate &&
            Mathf.Abs(Rig.velocity.x) > 1f &&
            (Rig.velocity.x > 0 && Transf.eulerAngles.y < 90 || Rig.velocity.x < 0 && Transf.eulerAngles.y > 90))
            {
                rotating = true;
                StartCoroutine(TurnAround(Rig.velocity.x > 0 ? 180 : 0));
            }

        }

        if (Input.GetAxis("Vertical") != 0)
        {

            CharacterOffestAddition += Input.GetAxis("Vertical") * .05f;
            CharacterOffestAddition = Mathf.Clamp(CharacterOffestAddition, 0.15f, 1.5f);
        }


        var ray = Physics2D.Raycast(CharacterOffest + Rig.position, Vector2.down, 100, LegMask);

        if (ray)
        {
            var pos = Rig.velocity;
            pos.y = (ray.point.y + 1f + CharacterOffestAddition) - Rig.position.y;
            pos.y *= Mathf.Abs(pos.y) * forceUp;
            Rig.velocity = pos;
        }



    }

    protected IEnumerator TurnAround(float targAngle)
    {
        rotating = true;
        var waiter = new WaitForFixedUpdate();
        var t = 0f;
        var angle = Transf.eulerAngles.y;
        while (t <= 1f)
        {
            angle = Mathf.Lerp(angle, targAngle, t);
            Transf.eulerAngles = Vector3.up * angle;
            t += 0.05f;
            yield return waiter;
        }

        Transf.eulerAngles = Vector3.up * targAngle;

        rotating = false;
        yield break;


    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
    }
}


