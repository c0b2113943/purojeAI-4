using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_RBG : MonoBehaviour
{
    GameObject text;
    GameObject text2;
    private int count=0;
    
    public AudioClip okSound;
    AudioSource audioSource; 


    // 表示するリスト
    private char[] characters = { 'r', 'g', 'b' };
    private List<string> colorList = new List<string> { "red", "green", "blue" };
    private List<Color> color = new List<Color>    {Color.red,Color.green, Color.blue};

    void Start()
    {
        
        this.text =GameObject.Find("Text");
        this.text2 =GameObject.Find("Text2");
        ShowRandomCharacter();
        this.audioSource = GetComponent<AudioSource>();

    }

       // Start is called before the first frame update
    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == this.gameObject.tag)
        {
            count++;
            this.audioSource.PlayOneShot(this.okSound);
            this.text2.GetComponent<Text>().text ="Score:"+count.ToString();
            ShowRandomCharacter();
            if (Score.mode==1)
            {
                Score.Score1 = count;
            }    
            if (Score.mode==2)
            {
                Score.Score2 = count;
            }  
        }

        else
        {
            if (Score.mode==1)
            {
                SceneManager.LoadScene("Start2");
            }

            else
            {
                SceneManager.LoadScene("Gameover");
            }
            
        }
           
    }


    private void ShowRandomCharacter()
    {
        // ランダムに文字を選んで表示
        int num =Random.Range(0, characters.Length);
        int num2 =Random.Range(0, characters.Length);
        if (Score.mode==2)
        {
           num2=num; 
        }
        string randomColor = colorList[num];
        this.text.GetComponent<Text>().text = randomColor.ToString();

        // テキストの色をランダムに変更
        Color textColor = color[num2];
        this.text.GetComponent<Text>().color = textColor;

        // テキストオブジェクトのタグをランダムな文字に変更
        
        char randomChar = characters[num];
        gameObject.tag = randomChar.ToString();
    }



}
