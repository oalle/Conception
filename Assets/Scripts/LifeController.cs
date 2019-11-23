using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject m_HeartsComponent;
    private  static int m_Life = 3;

    

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
            SoundManagerScript.PlaySound("PlayerHit");
            m_Life--;
            if (m_CoroutineAllowed)
            {
                StartCoroutine("Immortal");
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
}
