using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownMusique : MonoBehaviour
{
    Dropdown dpdwn;
    AudioSource audioS;
    public string select = "a";
    public string select2 = "b";
    public AudioClip[] Musique = new AudioClip[3];
    public static AudioClip playingClip;
    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        dpdwn = GetComponent<Dropdown>();
        this.GetComponent<Dropdown>().captionText.text = "Choix Musique";      
    }

    // Update is called once per frame
    void Update()
    {
        select = dpdwn.options[dpdwn.value].text;

        for(int i = 0; i < 3; i++)
        {
            //test = "égal"+i;
            if(dpdwn.value == i)
            {
                if (!audioS.isPlaying || !select.Equals(select2))
                {
                    if (!Musique[i].Equals(null))
                    {
                        audioS.clip = Musique[i];
                        playingClip = Musique[i];
                        audioS.Play();
                    }
                }
            }
        }
        select2 = select;
    }

    public static AudioClip GetMusique()
    {
        return playingClip;

    }
}
