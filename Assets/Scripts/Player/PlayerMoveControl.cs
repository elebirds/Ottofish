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
        // 检测鼠标左键点击
        if (Input.GetMouseButtonDown(0))
        {
            // 获取鼠标点击位置
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // 创建射线
            Ray2D ray = new Ray2D(clickPosition, Vector2.zero);
            // 设置射线长度，可以根据实际情况进行调整
            float rayLength = 0.1f;
            // 执行射线投射
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, rayLength);
            // 检查碰撞结果
            if (hit.collider != null && hit.collider.layerOverridePriority == 12)
            {
                // 处理点击的物体
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
        anim.SetBool("isRun", true);//run动画开始
        while (gameObject.transform.localPosition != to)
        {
            gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, to, 4 * Time.deltaTime);
            yield return 0;
        }
        anim.SetBool("isRun", false);//动画结束
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
