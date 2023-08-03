using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textcontlol : MonoBehaviour
{
    GameObject text2;
    GameObject text3;
    // Start is called before the first frame update
    void Start()
    {
        this.text2 =GameObject.Find("Text2");
        this.text2.GetComponent<Text>().text ="Score:"+Score.Score1.ToString();
        this.text3 =GameObject.Find("Text3");
        this.text3.GetComponent<Text>().text ="NormalScore:"+Score.Score2.ToString();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
