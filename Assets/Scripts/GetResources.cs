using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetResources : MonoBehaviour
{
    int m_PlayerLayer, m_ThisLayer;
    public UnityEngine.UI.Text m_WoodText, m_StoneText, m_IronText;
    private static int m_WoodNumber, m_StoneNumber, m_IronNumber;
    // Start is called before the first frame update
    void Start()
    {
        m_ThisLayer = this.gameObject.layer;
        m_PlayerLayer = LayerMask.NameToLayer("Player");

        Physics2D.IgnoreLayerCollision(m_PlayerLayer, m_ThisLayer, false);
        m_WoodNumber = 0;
        m_StoneNumber = 0;
        m_IronNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int.TryParse(m_WoodText.text.ToString(), out m_WoodNumber);
        int.TryParse(m_StoneText.text.ToString(), out m_StoneNumber);
        int.TryParse(m_IronText.text.ToString(), out m_IronNumber);
    }

    private void OnCollisionEnter2D(Collision2D p_Collision)
    {
        if (p_Collision.gameObject.tag.Equals("Player"))
        {
            if(this.tag.Equals("Wood"))
            {
                m_WoodNumber++;
                m_WoodText.text = m_WoodNumber.ToString();
                this.gameObject.SetActive(false);
            }
        }

        if (p_Collision.gameObject.tag.Equals("Player"))
        {
            if (this.tag.Equals("Stone"))
            {
                m_StoneNumber++;
                m_StoneText.text = m_StoneNumber.ToString();
                this.gameObject.SetActive(false);
            }
        }

        if (p_Collision.gameObject.tag.Equals("Player"))
        {
            if (this.tag.Equals("Iron"))
            {
                m_IronNumber++;
                m_IronText.text = m_IronNumber.ToString();
                this.gameObject.SetActive(false);
            }
        }
    }

    public static int GetWood()
    {
        return m_WoodNumber;
    }
    public static int GetStone()
    {
        return m_StoneNumber;
    }

    public static int GetIron()
    {
        return m_IronNumber;
    }
}
