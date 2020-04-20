using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    public bool melee = false;
    public float speed = 1f;
    public float distance = 10f;


    [Header("Body Setting")]
    public Rigidbody2D Body;
    public Rigidbody2D Hand;
    public Rigidbody2D Leg1;
    public Rigidbody2D Leg2;


    [Header("Eye Setting")]
    public Sprite DeadEye;

    public SpriteRenderer Eye1Rendered;
    public SpriteRenderer Eye2Rendered;

    public GameObject Attention;

    Animator animator;
    public bool Rdirection = true;
    public bool canmove = true;
    Transform detector;
    bool playerinview = false;
    bool hide = false;
    bool rotation = false;
    Transform player;
    public bool dead = false;

    void Start()
    {
        animator = gameObject.GetComponentInChildren(typeof(Animator)) as Animator;
        detector = transform.Find("detector")?.transform;
        animator.SetFloat("ASpeed", Random.Range(0.7f, 1.3f));
        speed = animator.GetFloat("ASpeed");
        Body.bodyType = RigidbodyType2D.Kinematic;
        Hand.bodyType = RigidbodyType2D.Kinematic;
        Leg1.bodyType = RigidbodyType2D.Kinematic;
        Leg2.bodyType = RigidbodyType2D.Kinematic;
    }

    public void Dead()
    {
        if (!enabled) return;
        dead = true;
        Hand.freezeRotation = false;
        Leg1.freezeRotation = false;
        Leg2.freezeRotation = false;

        Body.bodyType = RigidbodyType2D.Dynamic;
        Hand.bodyType = RigidbodyType2D.Dynamic;
        Leg1.bodyType = RigidbodyType2D.Dynamic;
        Leg2.bodyType = RigidbodyType2D.Dynamic;

        Body.gameObject.layer = 12;
        Hand.gameObject.layer = 13;
        Leg1.gameObject.layer = 13;
        Leg2.gameObject.layer = 13;
        Hand.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        Leg1.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        Leg2.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        //Leg1.gameObject.layer = 12;
        //Leg2.gameObject.layer = 12;

        Eye1Rendered.sprite = DeadEye;
        Eye2Rendered.sprite = DeadEye;
        Eye2Rendered.color = Color.white;

        animator.enabled = false;
        enabled = false;
        Body.AddForce(new Vector3(Random.Range(-0.3f, 0.3f), 1) * 1000f);
    }


    void FixedUpdate()
    {

        if (!playerinview && detector != null)
        {
            RaycastHit2D detection = Physics2D.Raycast
                    (detector.position,
                    (-(new Vector3(transform.position.x, detector.position.y)) + detector.position).normalized,
                    distance);
            Debug.DrawRay(detector.position, (-(new Vector3(transform.position.x, detector.position.y)) + detector.position).normalized, Color.green);
            if (detection.collider == true && detection.collider.tag == "Player")
            {
                Attention.SetActive(true);
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
        Body.gameObject.transform.localPosition = new Vector2(0.043701f, 1.7634f);
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
