using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    public bool melee = false;
    public float speed = 1f;
    public float distance = 10f;
    Animator animator;
    bool Rdirection = true;
    bool canmove = true;
    Transform detector;
    bool playerinview = false;
    bool hide = false;
    bool rotation = false;
    Transform player;

    void Start()
    {
        animator = gameObject.GetComponentInChildren(typeof(Animator)) as Animator;
        detector = transform.Find("detector").transform;
        animator.SetFloat("ASpeed", Random.Range(0.7f, 1.3f));
        speed = animator.GetFloat("ASpeed");
    }

    public void Dead()
    {
        animator.enabled = false;
        enabled = false;
    }


    void FixedUpdate()
    {

        if (!playerinview)
        {
            RaycastHit2D detection = Physics2D.Raycast
                    (detector.position,
                    (-(new Vector3(transform.position.x, detector.position.y)) + detector.position).normalized,
                    distance);
            Debug.DrawRay(detector.position, (-(new Vector3(transform.position.x, detector.position.y)) + detector.position).normalized, Color.green);
            if (detection.collider == true && detection.collider.tag == "Player")
            {

                playerinview = true;
                player = detection.transform;
            }
        }
        if (playerinview)
        {

            if (player.position.x > transform.position.x && Rdirection == false && !rotation)
            {
                rotation = true;
                StartCoroutine("Rotation");
            }
            if (player.position.x < transform.position.x && Rdirection == true && !rotation)
            {
                rotation = true;
                StartCoroutine("Rotation");
            }
            if (!rotation)
            {
                if (melee)
                {

                    if (Vector2.Distance(transform.position, player.position) > 4)
                    {
                        if (canmove)
                        {
                            transform.Translate(Vector2.right * speed * 2 * Time.fixedDeltaTime);
                            animator.SetBool("Walk", true);
                        }
                    }
                    else if (canmove) StartCoroutine("Melee");

                }
                else
                {
                    animator.SetBool("Walk", false);
                    if (!hide)
                    {
                        RaycastHit2D detection = Physics2D.Raycast
                        (detector.position,
                        (-(new Vector3(transform.position.x, detector.position.y)) + detector.position).normalized,
                        distance);
                        if (detection.collider == true && detection.collider.tag == "Player")
                        {
                            StartCoroutine("Attack");
                        }
                    }
                }
            }
        }
        if (!playerinview && canmove)
        {
            transform.Translate(Vector2.right * speed * 2 * Time.fixedDeltaTime);
            animator.SetBool("Walk", true);
            RaycastHit2D detection = Physics2D.Raycast
                (detector.position,
                //(transform.position- detector.position).normalized,
                Vector2.down,
                1.5f);
            if (detection.collider == true)
            {
                StartCoroutine("Rotation");
            }
        }
        if (!playerinview && !canmove)
        {
            animator.SetBool("Walk", false);
        }
    }
    IEnumerator Melee()
    {
        canmove = false;
        animator.SetBool("Walk", false);
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(1);
        canmove = true;
    }
    IEnumerator Attack()
    {

        hide = true;
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(1);
        animator.SetBool("Hide", true);

        yield return new WaitForSeconds(Random.Range(0.7f, 1.3f));
        animator.SetBool("Hide", false);
        hide = false;

    }

    IEnumerator Rotation()
    {
        rotation = true;
        canmove = false;

        yield return new WaitForSeconds(Random.Range(0.1f, 1.3f));
        //if (!playerinview)
        {
            animator.SetTrigger("Rotation");
            if (Rdirection)
            {
                detector.localPosition = new Vector2(-2.3f, 2);
                Rdirection = false;
            }
            else
            {
                detector.localPosition = new Vector2(2.3f, 2);
                Rdirection = true;
            }
            speed = -speed;
        }
        canmove = true;
        rotation = false;
    }
}
