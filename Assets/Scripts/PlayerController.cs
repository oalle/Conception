using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject m_HeartsComponent;
    private int m_Life = 3;
    public float m_Speed;
    public GameObject m_GameOverText;
    public GameObject m_RestartButton;

    int m_PlayerLayer, m_EnemyLayer;
    bool m_CoroutineAllowed = true;
    Image m_Sprite;
    void Start()
    {
        m_PlayerLayer = this.gameObject.layer;
        m_EnemyLayer = LayerMask.NameToLayer("Enemy");
        Physics2D.IgnoreLayerCollision(m_PlayerLayer, m_EnemyLayer, false);
        m_Sprite = GetComponent<Image>();


        m_GameOverText.SetActive(false);
        m_RestartButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.T))
        {
            if (m_Life != 0)
            {

                m_Life--;
                int l_HeartsCount = m_HeartsComponent.transform.childCount;
                for (int i = 0; i < l_HeartsCount - m_Life; i++)
                {
                    m_HeartsComponent.transform.GetChild(i).gameObject.SetActive(false);
                }
                //Jouer animation clignotement
            }
        }*/
        if (m_Life == 0)
        {
            SoundManagerScript.PlaySound("PlayerDeath");
            m_GameOverText.SetActive(true);
            m_RestartButton.SetActive(true);
            gameObject.SetActive(false);
        }
        RectTransform l_Rect = (RectTransform)transform;
        if (transform.position.y <= -l_Rect.rect.height/2)
        {
            SceneManager.LoadScene("GameOver");
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + m_Speed, transform.position.y);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position = new Vector3(transform.position.x - m_Speed, transform.position.y);
        }
        if(m_Life != 3)
        {
            int l_HeartsCount = m_HeartsComponent.transform.childCount;
            for (int i = 0; i < l_HeartsCount - m_Life; i++)
            {
                m_HeartsComponent.transform.GetChild(i).gameObject.SetActive(false);
            }
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
        var tempColor = m_Sprite.color;
        tempColor.a = 0.5f;
        m_Sprite.color = tempColor;
        yield return new WaitForSeconds(3f);
        m_CoroutineAllowed = true;
        Physics2D.IgnoreLayerCollision(m_PlayerLayer, m_EnemyLayer, false);
        var tempColor2 = m_Sprite.color;
        tempColor2.a = 1f;
        m_Sprite.color = tempColor2;
    }
}
