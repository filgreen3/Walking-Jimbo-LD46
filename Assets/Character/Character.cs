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
    public Vector2 CharacterOffestAddition = default;


    public Vector2 CharacterOffest => (characterOffest + CharacterOffestAddition) * timeShift;

    [SerializeField] private float forceUp = default;
    [SerializeField] private float move = default;
    [SerializeField] private float jump = default;
    [SerializeField] private float rote = default;


    float timeShift;


    protected bool rotating;
    protected virtual bool ExtraCoditionToRotate => true;




    protected virtual void FixedUpdate()
    {
        timeShift = 1 + (0.025f * Mathf.Sin(Time.timeSinceLevelLoad * 2));

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
        CharacterOffestAddition = Vector2.up * (1f + Input.GetAxis("Vertical") * jump);


        var ray = Physics2D.Raycast(CharacterOffest + Rig.position, Vector2.down, 6, LegMask);

        if (ray)
        {

            var pos = Rig.position;
            pos.y = ray.point.y + 1f + CharacterOffestAddition.y;
            Rig.position = pos;
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


