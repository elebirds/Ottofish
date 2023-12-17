using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintMoveRange : MonoBehaviour
{
    public GameObject pointPrefab; // Բ���ϵĵ��Ԥ����
    public int numberOfPoints = 360; // Բ���ϵĵ������
    public float radius = 2f; // Բ�İ뾶
    public Transform player; // ��ɫ��Transform

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
            // ����Բ���ϵĵ��λ��
            float angle = i * Mathf.PI * 2 / numberOfPoints;
            Vector3 position = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0f);

            // ����ʵ����������λ��
            GameObject point = Instantiate(pointPrefab, player.position + position, Quaternion.identity);
            // �������õ�ĸ���Ϊ��ɫ����ʹ������ɫһ���ƶ�
            point.transform.parent = gameObject.transform;
        }
    }
    public void ClearAllChildren()
    {
        // ��������������������
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
