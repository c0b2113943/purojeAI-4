using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCont : MonoBehaviour
{
    public Transform playerTransform; // プレイヤーのTransformを参照するための変数
    public Vector3 offset = new Vector3(0f, 3f, -12f); // カメラとプレイヤーの相対位置

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        if (playerTransform != null)
        {
            // プレイヤーの位置にオフセットを加えて、カメラの位置を設定
            transform.position = playerTransform.position + offset;
        }
    }
}
