using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public float speed;
    public float distance;

    private Animator anim;
    private bool isAlive = true;
    private bool movingRight = false;

    public Transform groundDetection;

    // Start is called before the first frame update
    void Start()
    {
        //GameManager.instance.AddEnemyToList (this);
        anim = GetComponent<Animator>();
        //target = GameObject.FindGameObjectWithTag ("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isMoving", true);
        //anim.SetBool("facePlayer", false);
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if(groundInfo.collider == false)
        {
            if(movingRight == true) 
            {
                //anim.SetBool("isMoving", true);
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
                StartCoroutine(Movement());
//                speed = 2;
            }
            else
            {
                //anim.SetBool("isMoving", true);
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
                StartCoroutine(Movement());
//                speed = 2;
            }
        }

    }

    IEnumerator Movement()
    {
//        print(Time.time);
        anim.SetBool("isMoving", false);
        int repeat = 5;
//        for(int i = 0 ; i < repeat ; i++)
//        {

            
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


    //        anim.SetBool("facePlayer", true);

            //yield return new WaitForSeconds (anim["Ennemy_attack"].length);
            //yield return new WaitForSeconds(5);
            speed = 2;
    //        print(Time.time);

//        }
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

            //Now, Wait until the current state is done playing
            while (counter < 5*(waitTime))
            {
                counter += Time.deltaTime;
                yield return null;
            }
            Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals ("Player_attack"))
        {
            StartCoroutine(Death());
        }
    }
}
