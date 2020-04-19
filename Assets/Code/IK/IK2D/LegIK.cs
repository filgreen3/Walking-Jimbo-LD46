using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegIK : GenericSubTargetIK
{

    public AnimationCurve curve;
    public float Speed;
    public bool ProcessState;

    [SerializeField] private LegIK ConnectedLeg;
    private float defVlaue = 0.5f;



    private Vector2 currPoint;
    private Vector2 savePoint;


    private Vector2 Point
    {
        get
        {
            if (ProcessState) return savePoint;

            var point = Physics2D.Raycast(targetObj.position, Vector2.down).point;

            if ((!ConnectedLeg.ProcessState && Mathf.Abs(point.x - savePoint.x) > defVlaue) ||
            Mathf.Abs(point.x - savePoint.x) > defVlaue * 1.5f)
            {
                currPoint = point;
                ProcessState = true;
                StartCoroutine(processMove());
            }
            savePoint.y = point.y;

            return savePoint;
        }
    }



    private void Start()
    {
        StopAllCoroutines();
        ProcessState = false;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        Bones[0].position = transform.position;

        for (int i = 1; i < Bones.Count; i++)
            Bones[i].position = Bones[i - 1].endPoint;
    }



    private IEnumerator processMove()
    {

        var waiter = new WaitForFixedUpdate();
        var t = 0f;

        while (t < defVlaue)
        {
            savePoint = Vector2.Lerp(savePoint, currPoint, t / defVlaue);
            savePoint.y += curve.Evaluate(t / defVlaue);
            t += 0.1f * Speed;
            yield return waiter;
        }
        savePoint = Vector2.Lerp(savePoint, currPoint, t / defVlaue);
        ProcessState = false;
        defVlaue = 1 - (Random.value / 20f);


    }


    public override Vector2 IKTarget => Point;



}

