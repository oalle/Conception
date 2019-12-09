using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject
{
    public float maxSpeed = 7;

    public AudioClip saut;

    private float temps;

    public static bool attack=false;

//    public AudioClip marche;

    protected AudioSource source;

    public float jumpTakeOffSpeed = 7;

    private int numberJump =0;

    private bool sprint = false;

    private SpriteRenderer spriteRenderer;

    private Animator animator;

    private static BoxCollider2D col;

 


    // Start is called before the first frame update
    void Awake()
    {
        col = GetComponent<BoxCollider2D>();
        source = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        /*if(grounded)
        {
            if (move.magnitude > minMoveDist)
            {
                if (!source.isPlaying)
                    source.PlayOneShot(marche);
            }
            else
            {
               // source.Stop();
            }
        }
        else
        {
            //source.Stop(); ;
        }*/

        if (Input.GetButtonDown("Sprint")&&grounded&&!sprint)
        {
            maxSpeed = maxSpeed * 1.8f;
            sprint = true;
            animator.SetBool("Sprint", true);
        }

        if (Input.GetButtonUp("Sprint")&&sprint)
        {
            maxSpeed = maxSpeed / 1.8f;
            sprint = false;
            animator.SetBool("Sprint", false);
        }
        
        if (Input.GetButtonDown("Jump")&&grounded)
        {
            source.PlayOneShot(saut);
            velocity.y = jumpTakeOffSpeed;
            numberJump = 1;
        }
        else if(Input.GetButtonDown("Jump")&&numberJump<2)
        {
            source.PlayOneShot(saut);
            velocity.y = jumpTakeOffSpeed;
            numberJump++;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y >0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }
        else if (grounded)
        {
            numberJump = 0;
        }

        if(Input.GetButtonDown("Fire") && (Time.time - temps > 2))
        {
            attack = true;
            animator.SetBool("Attack", true);
            temps=Time.time;
        }

        if (Input.GetButtonUp("Fire"))
        {
            
            animator.SetBool("Attack", false);
        }

        if (attack && (Time.time - temps > 2))
        {
            attack = false;
        }

        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));

        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        animator.SetBool("grounded", grounded);

        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }
    public static bool GetAttack()
    {
        return attack;
    }

    public static BoxCollider2D GetCollider()
    {
        return col;
    }
}
