using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownMusique : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Dropdown>().captionText.text = "Choix Musique";        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
