using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject m_HeartsComponent;
    private  static int m_Life;

    static private int m_Kills;

    int m_PlayerLayer, m_EnemyLayer;
    bool m_CoroutineAllowed = true;
    Renderer m_Sprite;
    Color m_Color;

    void Start()
    {
        m_PlayerLayer = this.gameObject.layer;
        m_EnemyLayer = LayerMask.NameToLayer("Ennemy");
        Physics2D.IgnoreLayerCollision(m_PlayerLayer, m_EnemyLayer, false);
        m_Sprite = GetComponent<Renderer>();
        m_Color = m_Sprite.material.color;
        m_Kills = 0;
        m_Life = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Life == 0)
        {
            SceneManager.LoadScene("LevelFinishGameOver");
        }
        else if (m_Life != 3)
        {
            int l_HeartsCount = m_HeartsComponent.transform.childCount;
            for (int i = 0; i < l_HeartsCount - m_Life; i++)
            {
                m_HeartsComponent.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        Transform l_Rect = transform;
        if (transform.position.y <= -30/2)
        {
            SceneManager.LoadScene("LevelFinishGameOver");
        }
        
    }

    private void OnCollisionEnter2D(Collision2D p_Collision)
    {
        if (p_Collision.gameObject.tag.Equals("Enemy"))
        {
            if (p_Collision.transform.position.y + 2.5 < this.transform.position.y)
            {
                m_Kills++;
            }
            else if(PlayerPlatformerController.GetAttack())
            {
                m_Kills++;
            }
            else
            {
                SoundManagerScript.PlaySound("PlayerHit");
                m_Life--;
                if (m_CoroutineAllowed)
                {
                    StartCoroutine("Immortal");
                }
            }
        }
    }

    IEnumerator Immortal()
    {
        m_CoroutineAllowed = false;
        Physics2D.IgnoreLayerCollision(m_PlayerLayer, m_EnemyLayer, true);
        m_Color.a = 0.5f;
        m_Sprite.material.color = m_Color;
        yield return new WaitForSeconds(3f);
        m_CoroutineAllowed = true;
        Physics2D.IgnoreLayerCollision(m_PlayerLayer, m_EnemyLayer, false);
        m_Color.a = 1f;
        m_Sprite.material.color = m_Color;
    }

    public static int GetLife()
    {
        return m_Life;
    }

    public static int GetKills()
    {
        return m_Kills;
    }

    void OnBecameInvisible()
    {
        if(!LevelControl.GetVictory())
            SceneManager.LoadScene("LevelFinishGameOver");
    }
}
