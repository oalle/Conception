using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InstantiatePlatform : MonoBehaviour
{

    // private GameObject samplePlatformPrefab;
    //private Renderer[] rend = new Renderer[4];
    private TilemapRenderer[] rend = new TilemapRenderer[4];
    private TilemapCollider2D[] col = new TilemapCollider2D[4];
    public float tab;
    public int numPlatform;
    public int numPlat;
    GameObject[] samplePlatform = new GameObject[4];
    private float sum = 0;
    public int cpt = 0;
    public float wait = 0;
    public float counterr = 0;
    private bool[] inAction = new bool[4];
  //  private bool canCollide = true;

    private bool enoughSound;

    // Start is called before the first frame update
    void Start()
    {
        numPlat = this.numPlatform;
        inAction[numPlat] = false;
        rend[numPlat] = GetComponent<TilemapRenderer>();
        col[numPlat] = GetComponent<TilemapCollider2D>();
        rend[numPlat].enabled = false;
        col[numPlat].enabled = false;
        enoughSound = true;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 512; i++)
        {
            sum += MusicChoice.samples[i];
            if (i == 128 || i == 256 || i == 384 || i == 511)
            {
                if (inAction[numPlat].Equals(false) && numPlat == cpt)
                {
                    if(canCollide(PlayerPlatformerController.GetCollider()))
                    {
                        inAction[numPlat] = true;
                        StartCoroutine(musicPlatform(sum));
                    }
                }
                cpt++;
                sum = 0;
            }
        }
        cpt = 0;
    }

    bool canCollide(BoxCollider2D playCol)
    {
        //Collider2D[] result;
        //playCol.OverlapCollider(col[numPlat], result);
        col[numPlat].enabled = true;
        if (playCol.IsTouching(col[numPlat]))
        {
            col[numPlat].enabled = false;
            return false;
        }
        else
        {
            col[numPlat].enabled = false;
            return true;
        }
    }

    IEnumerator musicPlatform(float waitTime)
    {
        float counter = 0;
        int cpt = 0;
        counterr = 0;

        tab = waitTime;
        waitTime = Mathf.Abs(waitTime);

        if (waitTime > 3.0e-03)
        {
            rend[numPlat].enabled = true;
            col[numPlat].enabled = true;
        }
        else
        {
            enoughSound = false;
            rend[numPlat].enabled = true;
            col[numPlat].enabled = true;
        }

        while (waitTime < 1 && cpt < 10) // multiply by 10 to get a wait time number > 10. Each sound range can have a huge difference, that's why i use while
        {
            waitTime *= 10;
            cpt++;
        }

        if (waitTime < 2 || waitTime > 5)
        {
            if (enoughSound)
            {
                waitTime = Random.Range(2.0f, 5.0f);
            }
            else
            {
                waitTime = Random.Range(1.0f, 2.0f);
            }
        }
        wait = waitTime;

        //Now, Wait until the current state is done playing
        while (counter < waitTime)
        {
            counter += Time.deltaTime;
            counterr = counter;
            yield return null;
        }

        rend[numPlat].enabled = false;
        col[numPlat].enabled = false;

        counter = 0;

        if (enoughSound)
        {
            waitTime = Random.Range(1.0f, 2.0f);
        }
        else
        {
            waitTime = Random.Range(2.0f, 5.0f);
        }

        while (counter < waitTime)
        {
            counter += Time.deltaTime;
            counterr = counter;
            yield return null;
        }
        inAction[numPlat] = false;
    }

}
