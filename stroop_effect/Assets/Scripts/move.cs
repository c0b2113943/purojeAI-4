using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.UI;

public class move : MonoBehaviour
{
    public string portName = "COM3"; // Arduinoが接続されているポート名
    public int baudRate = 9600; // Arduinoとの通信速度
    private SerialPort serialPort;
    private float moveSpeed  = 0.0009f; // オブジェクトの回転速度係数

    private float position=0;
    public float speed = 5f;
    public float zSpeed = 10f;
    GameObject text3;

    string data;

    void Start()
    {
        // シリアルポートを初期化
        serialPort = new SerialPort(portName, baudRate);
        serialPort.Open();

        zSpeed = 10f;
        this.text3 =GameObject.Find("Text3");
    }

    void Update()
    {
        float zMovement = zSpeed * Time.deltaTime;

        transform.Translate(0,0,zMovement);

        // Arduinoからデータを受信してオブジェクトを回転させる
        if (serialPort.IsOpen)
        {
            try
            {
                data = serialPort.ReadLine(); // シリアルポートからのデータ読み取り
                // string[] values = data.Split(','); // データをカンマで分割

             // MPU6050からのデータを解釈
                float xMove = float.Parse(data);
                float xact = xMove * moveSpeed * Time.deltaTime;
                
                if (position<=4.95f && position>=-4.95f){
                    position+=xact;
                    if (position>=4.95f){
                        position=4.95f;
                    }
                    if (position<=-4.95f){
                        position=-4.95f;
                    }
                }

                if (position>=-4.95f && position<-1.65f)
                {
                    this.text3.GetComponent<Text>().text ="";
                    this.transform.position= new Vector3(-3.3f,this.transform.position.y,this.transform.position.z);
                }

                else if (position>=-1.65 && position<1.65){
                    this.transform.position= new Vector3(0,this.transform.position.y,this.transform.position.z);
                }

                else if (position>=1.65 && position<=4.95){
                    this.text3.GetComponent<Text>().text ="";
                    this.transform.position= new Vector3(3.3f,this.transform.position.y,this.transform.position.z);
                }
                
                
                // オブジェクトの移動
                // Vector3 movement = new Vector3(xMove, 0f, 0f) * moveSpeed * Time.deltaTime;
                // transform.position += movement;
                // Vector3 currentPos = transform.position;
                // currentPos.x = Mathf.Clamp(currentPos.x,-xLimit, xLimit);
                // transform.position = currentPos;
            }
            catch (System.Exception)
            {
                Debug.LogWarning("Failed to read data from Arduino.");
            }
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




    // シリアルポートを閉じる
    void OnApplicationQuit()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }

}
