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


    float strange;
    float timeShift;

    private void Update()
    {
        var horiz = Input.GetAxis("Horizontal");
        if (horiz != 0)
        {
            Rig.AddForce(horiz * move * Vector2.right);
            if (Mathf.Abs(Rig.velocity.x) > 5f)
                Transf.eulerAngles = Vector3.up * ((Rig.velocity.x > 0) ? 180 : 0);

        }

        CharacterOffestAddition = Input.GetAxis("Vertical") * characterOffest * jump;

    }

    protected virtual void FixedUpdate()
    {
        var ray = Physics2D.Raycast(CharacterOffest + Rig.position, Vector2.down);
        strange = 1f - Mathf.Clamp01(ray.distance);

        Rig.rotation = Mathf.Atan2(ray.normal.y, ray.normal.x) * 57.2f - 90f;
        Rig.AddForce(Vector2.up * forceUp * strange);

        timeShift = 1 + (0.025f * Mathf.Sin(Time.timeSinceLevelLoad * 2));

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(characterOffest + Rig.position, Rig.position + Vector2.up * strange);
    }
}


