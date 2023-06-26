using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class prayercontolol : MonoBehaviour
{
    Rigidbody2D rigid2d;
    float yforce;
    float speed=5.0f;
    Animator animator;
    public bool zyanpu=false;   //続けてジャンプできないようにするため
    float sterttime=0.0f;   //スペースキー長押しの開始時間
    float endtime=0.0f; //スペースキー長押しの終わり時間
    bool spaseky=false; // 押している間プレイヤーを止めるため
    private float minJumpForce = 250f; // 最小のジャンプ力
    private float maxJumpForce = 500f; // 最大のジャンプ力
    private float minJumpForcex = 100f; // 最小のジャンプ力
    private float maxJumpForcex = 200f; // 最大のジャンプ力
    private float maxPress = 2f; // 最大の長押し時間
    bool clear =false;       //ゲームがクリアされたときのフラグ
    GameObject time;
    private clear_time cleartime;
    float sttime=0f;        //ゲームの開始時刻用


    // Start is called before the first frame update
    void Start()
    {
        this.rigid2d = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        sttime=Time.time;
    }

    // Update is called once per frame
    void Update()
    {   
        float hval = Input.GetAxis("Horizontal");
        
        if (clear==true && clear_time.stage==0)     //ノーマルのゲームのクリアなら
        {
            clear=false;
            clear_time.cleartime=Time.time-sttime;
            SceneManager.LoadScene("clear");
        }

        if (clear==true && clear_time.stage==1)     //錯覚のゲームクリアなら
        {
            clear=false;
            clear_time.cleartime2=Time.time-sttime;
            SceneManager.LoadScene("clear");
        }

        if (Input.GetKeyDown(KeyCode.Space) && zyanpu==false)   //スペースキーが押されたとき既に飛んでいなかったら
        {
            sterttime=Time.time;
            spaseky=true;
        }

        if (Input.GetKeyUp(KeyCode.Space) && zyanpu==false)     //スペースキーが離されたとき既に飛んでいなかったら
        {
            endtime=Time.time;
            float press = Mathf.Clamp(endtime - sterttime, 0f, maxPress); // スペースキーの押している長さを最大2秒に制限する
            float normalized = Mathf.Min(press / maxPress, 1f); // 正規化された長押し時間（0から1の範囲）を計算する（最大値を1に制限する）
            float jumpForceY = Mathf.Lerp(minJumpForce, maxJumpForce, normalized);  //Mathf.Lerp（min、max、割合）でmin~maxの間で割合によって数値を変える
            float jumpForceX = Mathf.Lerp(minJumpForcex, maxJumpForcex, normalized);
            zyanpu=true;
            this.rigid2d.AddForce(transform.up * jumpForceY);   //上方向に力を加える

            if (hval>0)     //スペースキーが離されたとき 右矢印 or D が押されていたら
            {
                this.rigid2d.AddForce(transform.right* jumpForceX); //右方向に力を加える
            }

            if (hval<0)     //スペースキーが離されたとき 左矢印 or A が押されていたら
            {
                this.rigid2d.AddForce(-transform.right*  jumpForceX);  //左方向に力を加える
            }
            
            this.animator.SetBool("upBool", true);
            spaseky=false;
        }

        if (this.rigid2d.velocity.y<0 && zyanpu==true)  //飛んでいるとき下方向に進んだら落下用のアニメーション再生用のBoolに変える
        {
            this.animator.SetBool("upBool", false);
            this.animator.SetBool("downBool", true);   
        }

        if (rigid2d.velocity.y >= 0 && zyanpu==true)    //飛んでいるとき上方向に進んだら飛んでいるときのアニメーション再生用のBoolに変える
        {
            this.animator.SetBool("upBool", true);
            this.animator.SetBool("downBool", false);
        }

        if (hval>0)
        {
            this.animator.SetBool("Bool", true); 
            this.transform.localScale = new Vector3(4, 4, 1);   //初期が右向きなのでスケール初期値にし右を向かせる
        }

        if (hval == 0)
        {
            this.animator.SetBool("Bool", false);       //止まっているときのモーションにするBoolの変更
        }
        if (hval<0)
        {
            this.animator.SetBool("Bool", true); 
            this.transform.localScale = new Vector3(-4, 4, 1);  //初期が右向きなのでXスケールをマイナスにし左を向かせる
        }

         
        if (spaseky==false && zyanpu==false)    //スペースキーが押されていなく、ジャンプしていない時のX座標の更新をする
        {
            transform.Translate(new Vector2(hval * speed * Time.deltaTime,0));
        }
        
        this.rigid2d.constraints = RigidbodyConstraints2D.FreezeRotation;   //回転しないようにする
        this.rigid2d.rotation = 0.0f;
        this.rigid2d.constraints = RigidbodyConstraints2D.None;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)     //このオブジェクトが他の物に当たった時
    {
        ContactPoint2D contact = collision.GetContact(0); //法線ベクトル取得
        
        if (contact.normal == Vector2.up) //法線ベクトルが上、つまり床に乗った時
        {
            rigid2d.velocity = Vector2.zero;
            this.animator.SetBool("downBool", false); 
            zyanpu=false;
        }

        else if (contact.normal == Vector2.right || contact.normal == Vector2.left)//法線ベクトルが右か左、つまり床や壁の横に当たった時
        {
            this.GetComponent<AudioSource>().Play();
            rigid2d.velocity = new Vector2(-rigid2d.velocity.x*2, rigid2d.velocity.y); //反射させる
        } 
        
        else if (contact.normal == Vector2.down)
        {
            this.GetComponent<AudioSource>().Play();    
        }
    }  

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        clear =true;
    }
}
