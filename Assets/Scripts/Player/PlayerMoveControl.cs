using Cinemachine;
using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMoveControl : MonoBehaviour
{
    [SerializeField]
    private int x, y;
    public int distante;
    public bool selected = false;
    private Animator anim;
    private SpriteRenderer render;

    private void Start()
    {
        anim = EntityManager.Instance.player.GetComponent<Animator>();
        render = EntityManager.Instance.player.GetComponent<SpriteRenderer>();
        this.moveTo(EntityManager.spawnX, EntityManager.spawnY, false);

    }

    private void Update()
    {
        if (RoundManager.Instance.state != State.PLAYER_MOVE) return;
        // ������������
        if (Input.GetMouseButtonDown(0))
        {
            // ��ȡ�����λ��
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // ��������
            Ray2D ray = new Ray2D(clickPosition, Vector2.zero);
            // �������߳��ȣ����Ը���ʵ��������е���
            float rayLength = 0.1f;
            // ִ������Ͷ��
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, rayLength);
            // �����ײ���
            if (hit.collider != null && hit.collider.layerOverridePriority == 12)
            {
                // ������������
                click();
            }
        }
    }

    public void moveTo(int x,int y, bool nextState)
    {
        this.x = x;
        this.y = y;
        Vector3 pos = MapManager.transformPosition4(x, y);
        StartCoroutine(realMove(pos,nextState));
    }

    IEnumerator realMove(Vector3 to, bool nextState)
    {
        EventManager.Broadcast<PlayerMoveEvent>(new PlayerMoveEvent(transform.position, to));
        render.flipX = (to.x - transform.position.x) > 0;
        anim.SetBool("isRun", true);//run������ʼ
        while (gameObject.transform.localPosition != to)
        {
            gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, to, 4 * Time.deltaTime);
            yield return 0;
        }
        anim.SetBool("isRun", false);//��������
        if(nextState)RoundManager.Instance.nextState();
    }

    public void displayBlockWhichCouldMove(bool show)
    {
        for (int i = math.max(1, x - distante);i<=math.min(MapManager.Instance.RowCount,x + distante); i++)
        {
            for (int j = math.max(1, y - distante); j <= math.min(MapManager.Instance.ColCount, y + distante); j++)
            {
                if (math.abs(i-x)+math.abs(j-y)<distante) MapManager.Instance.Blocks[i + "," + j].setSelected(show);
            }
        }
    }

    public void click()
    {
        Debug.Log("entre!");
        selected = !selected;
        displayBlockWhichCouldMove(selected);
    }
}
