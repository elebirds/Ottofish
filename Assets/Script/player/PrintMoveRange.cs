using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintMoveRange : MonoBehaviour
{
    public GameObject pointPrefab; // 圆周上的点的预制体
    public int numberOfPoints = 360; // 圆周上的点的数量
    public float radius = 2f; // 圆的半径
    public Transform player; // 角色的Transform

    private void Start()
    {
        CreateCircle();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            ClearAllChildren();
        }
    }

    public void MoveRange() 
    {
        Invoke("CreateCircle", 2f);
    }
    public void CreateCircle()
    {
        for (int i = 0; i < numberOfPoints; i++)
        {
            // 计算圆周上的点的位置
            float angle = i * Mathf.PI * 2 / numberOfPoints;
            Vector3 position = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0f);

            // 将点实例化并设置位置
            GameObject point = Instantiate(pointPrefab, player.position + position, Quaternion.identity);
            // 可以设置点的父级为角色，以使其跟随角色一起移动
            point.transform.parent = gameObject.transform;
        }
    }
    public void ClearAllChildren()
    {
        // 遍历并销毁所有子物体
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
