using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject m_HeartsComponent;
    private int m_Life = 3;
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
            }
        }
    }
}
