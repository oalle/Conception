using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Feedbacks : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject m_FullHearts;
    public UnityEngine.UI.Text m_Enemies, m_Woods, m_Stones, m_Irons;
    void Start()
    {
        int l_Woods = PlayerPlatformerController.GetWoods();
        m_Woods.text = l_Woods.ToString();
        int l_Stones = PlayerPlatformerController.GetStones();
        m_Stones.text = l_Stones.ToString();
        int l_Irons = PlayerPlatformerController.GetIrons();
        m_Irons.text = l_Irons.ToString();
        int l_Enemies = PlayerPlatformerController.GetEnemies();
        m_Enemies.text = l_Enemies.ToString();
        if (m_FullHearts != null)
        {
            int l_Life = LifeController.GetLife();
            int l_HeartsCount = m_FullHearts.transform.childCount;
            for (int i = 0; i < l_HeartsCount - l_Life; i++)
            {
                m_FullHearts.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGestionPart()
    {
        SceneManager.LoadScene("Gestion");
    }
}
