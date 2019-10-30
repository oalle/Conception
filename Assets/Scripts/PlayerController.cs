using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject m_HeartsComponent;
    private int m_Life = 3;
    public float m_Speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (m_Life != 0)
            {

                m_Life--;
                int l_HeartsCount = m_HeartsComponent.transform.childCount;
                print("hearts = " + l_HeartsCount);
                for (int i = 0; i < l_HeartsCount - m_Life; i++)
                {
                    print(i);
                    m_HeartsComponent.transform.GetChild(i).gameObject.SetActive(false);
                }
                //Jouer animation clignotement
            }
            if (m_Life == 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + m_Speed, transform.position.y);
        }
    }
}
