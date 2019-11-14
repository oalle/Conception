using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerDeath : MonoBehaviour
{
    public static AudioClip m_PlayerDeathSound;
    public GameObject m_GameOverText;
    static AudioSource m_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        m_PlayerDeathSound = Resources.Load<AudioClip>("PlayerDeath");

        m_AudioSource = GetComponent<AudioSource>();
        if(m_GameOverText.activeSelf)
            PlaySound("PlayerDeath");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string p_Clip)
    {
        switch (p_Clip)
        {
            case "PlayerDeath":
                m_AudioSource.volume = 0.3f;
                m_AudioSource.PlayOneShot(m_PlayerDeathSound);
                break;

            default:
                break;
        }
    }
}
