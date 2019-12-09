using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public float speed;
    private float spid;
    private bool dead = false;
    public float distance;
    int m_PlayerLayer, m_EnemyLayer;
    public AudioClip deathClip;
    public AudioClip moveClip;
    public AudioClip attackClip;
    AudioSource audioSource;
    BoxCollider2D m_Collider;

    private Animator anim;
    private bool isAlive = true;
    private bool movingRight = false;

    public Transform groundDetection;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        spid = speed;
        m_Collider = GetComponent<BoxCollider2D>();
        m_EnemyLayer = this.gameObject.layer;
        m_PlayerLayer = LayerMask.NameToLayer("Player");
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isMoving", true);
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if(groundInfo.collider == false)
        {
            if(movingRight == true) 
            {

                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
                StartCoroutine(Movement());
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
                StartCoroutine(Movement());

            }
        }
    }

    IEnumerator Movement()
    {
        anim.SetBool("isMoving", false);   
        anim.Play("Ennemy_idle");

        speed = 0;
        transform.Translate(Vector2.right * speed * Time.deltaTime);


        float counter = 0;
        float waitTime = anim.GetCurrentAnimatorStateInfo(0).length;

        //Now, Wait until the current state is done playing
        while (counter < (waitTime))
        {
            counter += Time.deltaTime;
            yield return null;
        }
        speed = spid;
        AudioSource.PlayClipAtPoint (moveClip, transform.position);
    }

    IEnumerator Death()
    {
        anim.SetBool("isMoving", false);
        anim.SetBool("isAttack", true);
        anim.SetBool("isAlive", false);

        anim.Play("Ennemy_die");

        speed = 0;
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        float counter = 0;
        float waitTime = anim.GetCurrentAnimatorStateInfo(0).length;

        AudioSource.PlayClipAtPoint (deathClip, transform.position);

        //Now, Wait until the current state is done playing
        while (counter < 5*(waitTime))
        {
            counter += Time.deltaTime;
            yield return null;
        }

        Physics2D.IgnoreLayerCollision(m_PlayerLayer, m_EnemyLayer, false);
        Destroy(gameObject);
    }

    IEnumerator Attack(Collision2D col)
    {
        anim.SetBool("isMoving", false);
        anim.Play("Ennemy_attack");

        speed = 0;
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        float counter = 0;
        float waitTime = anim.GetCurrentAnimatorStateInfo(0).length;

        AudioSource.PlayClipAtPoint(attackClip, transform.position);

        //Now, Wait until the current state is done playing
        while (counter < waitTime)
        {
            counter += Time.deltaTime;
            yield return null;
        }
        speed = spid;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Player")&&PlayerPlatformerController.GetAttack())
        {
            StartCoroutine(Death());
        }
        else if (col.gameObject.tag.Equals("Player"))
        {
            // while (col.gameObject.tag.Equals("Player"))
            if (col.transform.position.y > this.transform.position.y + 2.5)
            {
                if (!dead) {
                    dead = true;
                    Physics2D.IgnoreLayerCollision(m_PlayerLayer, m_EnemyLayer, true);
                    StartCoroutine(Death());
                }
            }
            else
            {
                if(!dead) StartCoroutine(Attack(col));
            }
        }
    }
}
