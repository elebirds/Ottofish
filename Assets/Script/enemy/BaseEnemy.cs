using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BaseEnemy : MonoBehaviour
{
    public float speed;
    public GameObject duodian;
    public EnemyCallMagic call;
    public Transform target; // 目标角色的Transform
    public float moveDistance = 1f; // 每次移动的固定距离

    private void Start()
    {
        call = GetComponent<EnemyCallMagic>();
    }
    private void Update()
    {
        if (TurnContoller.turn%2 == 1) 
        {
            //gameObject.transform.position = Vector3.Lerp(transform.position, duodian.transform.position, 0.001f);
            MoveAway();
            StartCoroutine(callmagic()); 
            
        }
    }
    public void tunnStart() 
    {
        StartCoroutine(callmagic()); 
    }
    public void move() 
    {
        //gameObject.transform.position = Vector3.Lerp(transform.position, duodian.transform.position, 0.001f);
    }
    IEnumerator callmagic() 
    {
        
        yield return new WaitForSeconds(2);
        call.callmagic();
        gameObject.SetActive(true);
        TurnContoller.turn++;
    }
    void MoveAway()
    {
        // 计算方向向量
        Vector3 direction = transform.position - target.position;
        Vector3 newPosition = transform.position + direction.normalized * moveDistance;
        gameObject.transform.position = Vector3.Lerp(transform.position, newPosition, 0.001f);
    }
}
