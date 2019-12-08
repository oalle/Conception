using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    //DropDownMusique Ddm;
    //private string musique;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGameBtn(string game)
    {
        //musique = Ddm.GetMusique();
    	SceneManager.LoadScene(game);
    }

    public void ExitGameBtn()
    {
    	Application.Quit();
    }

    public void ResetBtn()
    {
        Gestion.Reset();
    }
}
