using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class start : MonoBehaviour
{
    GameObject text3;
    // Start is called before the first frame update
    void Start()
    {
        this.text3 =GameObject.Find("Text3");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Score.mode++;
            if (Score.mode2==0){
                SceneManager.LoadScene("Main"); //ゲーム画面に行く
            }
            else
                SceneManager.LoadScene("Main2"); //ゲーム画面(コントローラー)に行く
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            this.text3.GetComponent<Text>().text ="Sensor mode";
            Score.mode2++;
            
        }
        
    }
}
