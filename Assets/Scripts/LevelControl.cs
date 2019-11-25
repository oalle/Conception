using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{

    private static bool m_Victory;

    // Start is called before the first frame update
    void Start()
    {
        m_Victory = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
    	if(other.CompareTag("Player"))
    	{
    		StartCoroutine(Exit());
    	}
    }

    IEnumerator Exit()
    {
    	yield return new WaitForSeconds(2);
        m_Victory = true;
   		SceneManager.LoadScene("LevelFinishVictory");
    }

    public static bool GetVictory()
    {
        return m_Victory;
    }
}
