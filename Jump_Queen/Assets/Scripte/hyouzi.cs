using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hyouzi : MonoBehaviour
{
    GameObject time;
    GameObject Text; 
    GameObject Text2; 
    GameObject Text3;
    GameObject Text4;
    private clear_time cleartime;

    // Start is called before the first frame update
    void Start()
    {
        Text =GameObject.Find("Texttime"); 
        Text2 =GameObject.Find("Texttime (1)"); 
        Text3 =GameObject.Find("next"); 
        Text4 =GameObject.Find("Text (Legacy)"); 
        // Text.GetComponent<Text>().text ="Normal mode clear time : "+clear_time.cleartime.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        if (clear_time.stage==0)
        {
           Text.GetComponent<Text>().text ="Normal mode clear time : "+clear_time.cleartime.ToString("F2"); 
        }

        if (clear_time.stage==1)
        {
            Text.GetComponent<Text>().text ="Normal mode clear time : "+clear_time.cleartime.ToString("F2"); 
            Text2.GetComponent<Text>().text ="illusion mode clear time : "+clear_time.cleartime2.ToString("F2"); 
            Text3.GetComponent<Text>().text ="";
            Text4.GetComponent<Text>().text ="Game Clear";
        }
    }
}
