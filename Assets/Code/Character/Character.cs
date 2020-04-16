using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    [SerializeField] protected Transform Transf;
    [SerializeField] protected ArmIK[] Arms = default;



    public Rigidbody2D Rig;
    [SerializeField] private Vector2 characterOffest = default;
    public Vector2 CharacterOffestAddition = default;


    public Vector2 CharacterOffest => (characterOffest + CharacterOffestAddition) * timeShift;

    [SerializeField] private float forceUp = default;
    [SerializeField] private float move = default;
    [SerializeField] private float jump = default;
    [SerializeField] private float rote = default;


    float strange;

    float strange1;
    float strange2;

    float timeShift;

    private void Update()
    {

        Rig.rotation = (strange1 - strange2) * rote;

        if (Input.GetAxis("Horizontal") != 0)
        {
            Rig.AddForce(Input.GetAxis("Horizontal") * move * Vector2.right);
        }

        CharacterOffestAddition = Input.GetAxis("Vertical") * characterOffest * jump;

    }

    protected virtual void FixedUpdate()
    {
        strange1 = 1f - Mathf.Clamp01(Physics2D.Raycast(Vector2.right * 0.2f + CharacterOffest + Rig.position, Vector2.down).distance);
        strange2 = 1f - Mathf.Clamp01(Physics2D.Raycast(Vector2.left * 0.2f + CharacterOffest + Rig.position, Vector2.down).distance);

        strange = (strange1 + strange2) / 2f;

        Rig.AddForce(Vector2.up * forceUp * strange);

        timeShift = 1 + (0.1f * Mathf.Sin(Time.timeSinceLevelLoad * 2));

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(characterOffest + Rig.position, Rig.position + Vector2.up * strange);
    }
}


