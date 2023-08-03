using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movetest : MonoBehaviour
{
    public float speed = 5f;
    public float zSpeed = 10f;
    private int count = 1;
    GameObject text3;

    // Start is called before the first frame update
    void Start()
    {
        zSpeed = 10f;
        this.text3 =GameObject.Find("Text3");
    }

    // Update is called once per frame
    void Update()
    {
        float zMovement = zSpeed * Time.deltaTime;

        transform.Translate(0,0,zMovement);
        
        //countで現在位置の更新を行う
        if (Input.GetKeyDown(KeyCode.RightArrow) && count<2)
        {
            this.text3.GetComponent<Text>().text ="";
            count++;     
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && count>0)
        {
            this.text3.GetComponent<Text>().text ="";
            count--;
        }

        //重力の関係か勝手に進むので毎回更新する
        if (count==0)
            {
                this.transform.position= new Vector3(-3.3f,this.transform.position.y,this.transform.position.z);
            }
        
        else if (count==1)
            {
                this.transform.position= new Vector3(0,this.transform.position.y,this.transform.position.z);
            }
        
        else if (count==2)
            {
                this.transform.position= new Vector3(3.3f,this.transform.position.y,this.transform.position.z);
            }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Score.mode==1){
            if(Score.Score1!=0){
                if(Score.Score1%5==0){
                    zSpeed++;
                }
            }
        }

        if (Score.mode==2){
            if(Score.Score2!=0){
                if(Score.Score2%5==0){
                    zSpeed++;
                }
            }
        }
        
    }

}

