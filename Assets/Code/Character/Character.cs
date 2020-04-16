using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Rigidbody2D Rig;
    [SerializeField] private Vector2 characterOffest = default;

    [SerializeField] private float forceUp = default;
    [SerializeField] private float move = default;
    [SerializeField] private float jump = default;
    [SerializeField] private float rote = default;


    float strange;

    float strange1;
    float strange2;



    private void Update()
    {

        Rig.rotation = (strange1 - strange2) * rote;

        if (Input.GetAxis("Horizontal") != 0)
        {
            Rig.AddForce(Input.GetAxis("Horizontal") * move * Vector2.right);
        }
        if (Input.GetAxis("Vertical") > 0 && strange1 != 0)
        {
            Rig.AddForce(jump * transform.up);
        }
    }

    private void FixedUpdate()
    {
        strange1 = 1f - Mathf.Clamp01(Physics2D.Raycast(Vector2.right * 0.2f + characterOffest + Rig.position, Vector2.down).distance);
        strange2 = 1f - Mathf.Clamp01(Physics2D.Raycast(Vector2.left * 0.2f + characterOffest + Rig.position, Vector2.down).distance);

        strange = (strange1 + strange2) / 2f;

        Rig.AddForce(Vector2.up * forceUp * strange);

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(characterOffest + Rig.position, Rig.position + Vector2.up * strange);
    }
}


