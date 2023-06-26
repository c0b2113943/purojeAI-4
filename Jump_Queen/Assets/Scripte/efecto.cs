using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class efecto : MonoBehaviour
{
    GameObject player;
    Animator animator;
    bool Zyanpu;
    private prayercontolol Prayercontolol;
    float sterttime;
    float nowtime;
    Color originalColor;
    bool mode=false;

    // Start is called before the first frame update
    void Start()
    {
        this.player=GameObject.Find("player");
        // player = GameObject.Find("player");
        Prayercontolol = player.GetComponent<prayercontolol>();
        this.animator = GetComponent<Animator>(); 
        sterttime=0.0f;
        originalColor = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        Zyanpu=Prayercontolol.zyanpu;
        nowtime=Time.time;

        if (Input.GetKeyDown(KeyCode.Space) && Zyanpu==false)
        {
            GetComponent<Renderer>().material.color=originalColor;
            sterttime=Time.time;
            this.animator.SetBool("efectoBool", true);
        }

        if (Input.GetKeyUp(KeyCode.Space) && Zyanpu==false)
        {
            this.GetComponent<AudioSource>().Play();
            this.animator.SetBool("efectoBool", false);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            mode = !mode;
        }
       
        if (mode)
        {
            if (nowtime-sterttime>=2.0f)
            {
                GetComponent<Renderer>().material.color=new Color(255.0f,0.0f,0.0f,0.2f );
            }
            else if (nowtime-sterttime>=1.0f)
            {
                GetComponent<Renderer>().material.color=new Color(251.0f,255.0f,0.0f,0.1f );
            }
        }
        
        float playerx = this.player.transform.position.x;
        float playery = this.player.transform.position.y;
        transform.position = new Vector3(playerx, playery+2.44f, 0);
    }
}
