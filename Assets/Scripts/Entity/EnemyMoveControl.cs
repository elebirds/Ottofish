using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class EnemyMoveControl : MonoBehaviour
{
    public int id;
    public bool isBoss;
    private SpriteRenderer render;
    public float canMoveDistance;
    public static int moveCount;
    public static int attackCount;
    public void changeColor()
    {
        render.color = RandomUtils.randomColor();
    }

    public void move()
    {
        if (isBoss)
        {
            StartCoroutine(bossRealMove());

        }
        else
        {
            StartCoroutine(enemyRealMove());
        }
        moveCount++;
        if (moveCount >= EntityManager.Instance.activeEnemyCount)
        {
            RoundManager.Instance.nextState();
            moveCount = 0;
        }
    }
    public void attack()
    {
        if (isBoss)
        {
            SkillManager.Instance.callSkill("冰柱术", EntityManager.Instance.playerMove.transform.position);
        }
        else
        {
            float distance = Vector3.Distance(EntityManager.Instance.playerMove.transform.position, transform.position);
            if (distance < 2 * 0.65) 
            {
                StartCoroutine(MoveToTargetAndReturn());
            }
        }
        attackCount++;
        if (attackCount >= EntityManager.Instance.activeEnemyCount)
        {
            RoundManager.Instance.nextState();
            attackCount = 0;
        }
    }


    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        this.changeColor();
        canMoveDistance = 2;
    }

    IEnumerator bossRealMove()
    {
        Vector3 currentPlace = gameObject.transform.position;
        Vector3 target = EntityManager.Instance.playerMove.transform.position;
        // 计算方向向量
        Vector3 direction = -1 * (target - transform.position);
        // 计算当前距离
        float distance = Vector3.Distance(target, transform.position);
        while (distance < 5 * 0.64 && Vector3.Distance(gameObject.transform.position, currentPlace) < canMoveDistance)
        {
            // 计算每帧移动的距离
            float frameMoveDistance = 1.2f * Time.deltaTime;
            // 计算每次移动的位置
            Vector3 newPosition = transform.position + direction.normalized * frameMoveDistance;
            // 移动到新的位置
            transform.position = newPosition;
            distance = Vector3.Distance(target, transform.position);
            yield return 0;
        }
    }
    IEnumerator enemyRealMove() 
    {
        Vector3 currentPlace = gameObject.transform.position;
        Vector3 target = EntityManager.Instance.playerMove.transform.position;
        Vector3 direction = target - transform.position;
        float distance = Vector3.Distance(target, transform.position);
        while (distance > 2 * 0.64 && Vector3.Distance(gameObject.transform.position, currentPlace) < canMoveDistance)
        {
            float frameMoveDistance = 1.2f * Time.deltaTime;
            Vector3 newPosition = transform.position + direction.normalized * frameMoveDistance;
            transform.position = newPosition;
            distance = Vector3.Distance(target, transform.position);
            yield return 0;
        }
    }
    IEnumerator MoveToTargetAndReturn()
    {
        Vector3 chushi = gameObject.transform.position; 
        yield return MoveTo(EntityManager.Instance.playerMove.transform.position);
        EntityManager.Instance.player.GetComponent<Character>()?.TakeDamage(10);
        yield return MoveTo(chushi);
    }

    IEnumerator MoveTo(Vector3 destination)
    {
        while (transform.position != destination)
        {
            // 计算方向向量
            Vector3 direction = destination - transform.position;

            // 计算每帧移动的距离，乘以 Time.deltaTime 以使运动更加平滑
            float frameMoveDistance = 2 * Time.deltaTime;

            // 计算每次移动的位置
            Vector3 newPosition = transform.position + direction.normalized * frameMoveDistance;

            // 移动到新的位置
            transform.position = newPosition;

            // 等待下一帧
            yield return null;
        }
    }
}
