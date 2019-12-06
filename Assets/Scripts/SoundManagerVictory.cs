using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerVictory : MonoBehaviour
{
    public static AudioClip m_VictorySound;
    static AudioSource m_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        m_VictorySound = Resources.Load<AudioClip>("Victory");

        m_AudioSource = GetComponent<AudioSource>();
        PlaySound("Victory");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string p_Clip)
    {
        switch (p_Clip)
        {
            case "Victory":
                m_AudioSource.volume = 0.3f;
                m_AudioSource.PlayOneShot(m_VictorySound);
                break;

            default:
                break;
        }
    }
}
