using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    //DropDownMusique Ddm;
    //private string musique;
    public Button nextLevel;
    private static bool onlyVictory = false;
    public string btnName = "ey";
    private ColorBlock myCB;

    // Start is called before the first frame update
    void Start()
    {
        nextLevel.GetComponent<Button>();
        if (!onlyVictory)
        {
            nextLevel.enabled = false;

            myCB = nextLevel.colors;

//            myCB.normalColor = new Color(140, 105, 79);
  //          myCB.highlightedColor = new Color(140, 105, 79);

            myCB.normalColor = Color.gray;
            myCB.highlightedColor = Color.gray;

            nextLevel.colors = myCB;
            btnName = nextLevel.ToString();


            //nextLevel.colors.normalColor = new Color(140, 105, 79);

            //nextLevel.GetComponent<Image>().color = new Color(140, 105, 79);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Color not ready 8C694F
        //Color ready
     
        if(LevelControl.GetVictory() && !onlyVictory)
        {
            onlyVictory = true;
            myCB.normalColor = Color.white;
            myCB.highlightedColor = Color.white;
            nextLevel.colors = myCB;
//            nextLevel.GetComponent<Image>().color = new Color(255, 255, 255);
            nextLevel.enabled = true;
        }
    }

    public void PlayGameBtn(string game)
    {
        //musique = Ddm.GetMusique();
        /*if (game.Equals("level2") && LevelControl.GetVictory())
        {
            nextLevel.GetComponent<Image>().color = new Color(255, 255, 255);
            nextLevel.enabled = false;
        }*/
        if (onlyVictory || game.Equals("level1"))
        {
            SceneManager.LoadScene(game);
        }
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
