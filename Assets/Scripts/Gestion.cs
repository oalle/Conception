using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gestion : MonoBehaviour
{
    private static bool m_reset = false;
    public UnityEngine.UI.Text m_Woods, m_Stones, m_Irons;
    private static int m_AllWood = 0, m_AllStone = 0, m_AllIron = 0;
    // Start is called before the first frame update
    void Start()
    {
        int l_Woods = GetResources.GetWood();
        m_AllWood += l_Woods;
        m_Woods.text = m_AllWood.ToString();
        int l_Stones = GetResources.GetStone();
        m_AllStone += l_Stones;
        m_Stones.text = m_AllStone.ToString();
        int l_Irons = GetResources.GetIron();
        m_AllIron += l_Irons;
        m_Irons.text = m_AllIron.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_reset)
        {
            m_Woods.text = m_AllWood.ToString();
            m_Stones.text = m_AllStone.ToString();
            m_Irons.text = m_AllIron.ToString();
            m_reset = false;
        }

    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("wood", m_AllWood);
        PlayerPrefs.SetInt("stone", m_AllStone);
        PlayerPrefs.SetInt("iron", m_AllIron);
    }

    void OnEnable()
    {
        m_AllWood = PlayerPrefs.GetInt("wood");
        m_AllStone = PlayerPrefs.GetInt("stone");
        m_AllIron = PlayerPrefs.GetInt("iron");
    }

    public static void Reset()
    {
        m_AllWood = 0;
        m_AllStone = 0;
        m_AllIron = 0;
        m_reset = true;
    }
}
