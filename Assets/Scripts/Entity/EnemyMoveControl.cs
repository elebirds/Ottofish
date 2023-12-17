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
            SkillManager.Instance.callSkill("������", EntityManager.Instance.playerMove.transform.position);
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
        // ���㷽������
        Vector3 direction = -1 * (target - transform.position);
        // ���㵱ǰ����
        float distance = Vector3.Distance(target, transform.position);
        while (distance < 5 * 0.64 && Vector3.Distance(gameObject.transform.position, currentPlace) < canMoveDistance)
        {
            // ����ÿ֡�ƶ��ľ���
            float frameMoveDistance = 1.2f * Time.deltaTime;
            // ����ÿ���ƶ���λ��
            Vector3 newPosition = transform.position + direction.normalized * frameMoveDistance;
            // �ƶ����µ�λ��
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
            // ���㷽������
            Vector3 direction = destination - transform.position;

            // ����ÿ֡�ƶ��ľ��룬���� Time.deltaTime ��ʹ�˶�����ƽ��
            float frameMoveDistance = 2 * Time.deltaTime;

            // ����ÿ���ƶ���λ��
            Vector3 newPosition = transform.position + direction.normalized * frameMoveDistance;

            // �ƶ����µ�λ��
            transform.position = newPosition;

            // �ȴ���һ֡
            yield return null;
        }
    }
}
