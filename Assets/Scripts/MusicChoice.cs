using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicChoice : MonoBehaviour
{
    AudioSource audioS;
    private AudioClip musicClip;
    public static float[] samples = new float[512];
    // 0 <=> base, and 512 ~20K Hz


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

    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
    }

    void GetSpectrumAudioSource()
    {
        audioS.GetSpectrumData(samples, 0, FFTWindow.Blackman);
        // 0 <=> channel, FFTWindow.Blackman : reduce leakage of spectrum data
    }
}
