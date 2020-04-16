using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegIKLineRender : GenericIKFixedPoint
{
    [SerializeField] private AnimationCurve moveCurve;
    [SerializeField] private float speed;

    [SerializeField] private LegIKLineRender connectedLeg;

    private Vector2 currPoint;
    public Vector2 savePoint;

    [SerializeField] private float legoOffset;

    private bool process;

    private Vector2 Point
    {
        get
        {
            if (process) return savePoint;
            var point = Physics2D.Raycast(target.position, Vector3.down).point;

            if ((point - savePoint).magnitude > 1)
            {
                currPoint = point + (point - savePoint).normalized * 0.75f;
                currPoint += (Mathf.Abs(connectedLeg.savePoint.x - savePoint.x) < 0.15f) ? Vector2.right * legoOffset : Vector2.zero;
                StartCoroutine(processMove());
            }

            return savePoint;
        }
    }


    protected override void Update()
    {
        base.Update();

        Bones.SetPosition(Bones.positionCount - 1, savePoint);

    }



    private IEnumerator processMove()
    {
        process = true;

        var waiter = new WaitForFixedUpdate();
        var t = 0f;

        while (t < 1f)
        {
            savePoint = Vector3.LerpUnclamped(savePoint, currPoint, t);
            savePoint.y += moveCurve.Evaluate(t);
            t += 0.1f * speed;
            yield return waiter;
        }
        savePoint = currPoint;
        process = false;
    }

    public override Vector3 IKTarget => Point;
}

