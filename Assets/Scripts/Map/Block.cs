using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BlockType
{
    Normal,
    Obstacle//障碍物
}

public class Block : MonoBehaviour
{
    public int X;
    public int Y;
    public bool canCross = true;
    public BlockType Type = BlockType.Normal;//格子类型
    private bool selected = false;
    private SpriteRenderer render;

    private void OnEnable()
    {
        render = GetComponent<SpriteRenderer>();
    }

    private void OnMouseEnter()
    {
        //Debug.Log(X + "," + Y + "entre");
        //setSelected(true);
    }
    private void OnMouseExit()
    {
        //Debug.Log(X + "," + Y + "leave");
        //setSelected(false);
    }

    private void OnMouseDown()
    {
        if (RoundManager.Instance.state != State.PLAYER_MOVE) return;
        Debug.Log(X + "," + Y + "click");
        if (this.selected&&EntityManager.Instance.playerMove.selected)
        {
            EntityManager.Instance.playerMove.selected = false;
            EntityManager.Instance.playerMove.displayBlockWhichCouldMove(false);
            EntityManager.Instance.playerMove.moveTo(X,Y, true);
        }
    }


    private void changeNormal()
    {
        render.color = Color.green;
    }

    public void setSelected(bool isSelect)
    {
        selected = isSelect;
        if (selected)
        {
            render.color = Color.red;
        }
        else
        {
            changeNormal();
        }
    }
}
