using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChoice : MonoBehaviour
{
    AudioSource audioS;
    private AudioClip musicClip;
    
    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        musicClip = DropDownMusique.GetMusique();
        if (!musicClip.Equals(null))
        {
            audioS.clip = musicClip;
            audioS.Play();
        }
        

        //audioS.clip = Musique[i];
        //test = audioS.clip.ToString();
        //audioS.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
