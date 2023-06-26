using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        this.player=GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        float playerY = this.player.transform.position.y;

        if (playerY>=15.5f)
        {
            transform.position = new Vector3(transform.position.x,20.0f,transform.position.z);  
        }
          
        else if (playerY>=5.0f)
        {
            transform.position = new Vector3(transform.position.x,10.0f,transform.position.z);  
        }

        else if (playerY<5.0f)
        {
            transform.position = new Vector3(transform.position.x,0,transform.position.z);
        }

        
    }
}
