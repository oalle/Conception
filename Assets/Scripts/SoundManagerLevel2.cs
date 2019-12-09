using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerLevel2 : MonoBehaviour
{
    public static AudioClip m_PlayerHitSound, m_PlayerDeathSound;
    static AudioSource m_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        m_PlayerHitSound = Resources.Load<AudioClip>("PlayerHit");
        m_PlayerDeathSound = Resources.Load<AudioClip>("PlayerDeath");

        m_AudioSource = GetComponent<AudioSource>();

        //DontDestroyOnLoad(m_AudioSource);
    }

    // Update is called once per frame
    void Update()
    {
        m_PlayerHitSound = Resources.Load<AudioClip>("PlayerHit");
        m_PlayerDeathSound = Resources.Load<AudioClip>("PlayerDeath");
    }

    public static void PlaySound(string p_Clip)
    {
        switch (p_Clip)
        {
            case "PlayerHit":
                m_AudioSource.PlayOneShot(m_PlayerHitSound);
                break;
            case "PlayerDeath":
                m_AudioSource.volume = 0.3f;
                m_AudioSource.PlayOneShot(m_PlayerDeathSound);
                break;

            default:
                break;
        }
    }
}
