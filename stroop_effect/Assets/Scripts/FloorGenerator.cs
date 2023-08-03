using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    float span = 39.0f;  // span進むと1回生成する
    public GameObject[] floorlist = new GameObject[6];
    public Transform playerTransform;
    float lastZPosition = 0f;
    float destroyDistance = 100f; // 画面外に出た床を削除する距離

    void Start()
    {
        GenerateFloor(40f);
        GenerateFloor(80f);
    }

    void Update()
    {
        float playerZPosition = playerTransform.position.z;
        if (playerZPosition - lastZPosition >= span)
        {
            // プレイヤーが一定距離(span)進むごとに新しい床を生成します
            GenerateFloor(playerZPosition + 80f);
            lastZPosition += span;
        }

        // 画面外に出た床を削除します
        GameObject[] floors = GameObject.FindGameObjectsWithTag("Floor");
        foreach (GameObject floor in floors)
        {
            if (floor.transform.position.z < playerZPosition - destroyDistance)
            {
                Destroy(floor);
            }
        }
    }

    void GenerateFloor(float zPosition)
    {
        int index = Random.Range(0, 6);
        GameObject floorPrefab = floorlist[index];
        Instantiate(floorPrefab, new Vector3(0, 0, zPosition), Quaternion.identity);
    }
}
