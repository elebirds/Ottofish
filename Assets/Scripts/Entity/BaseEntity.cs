using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEntity : MonoBehaviour{
    //������Ϣ
    protected Guid id;
    protected string nickname;

    //����
    protected float health; //Ѫ��
    protected float shield; //����ֵ
    protected List<ElementType> weaknesses; //��������
    protected int skillPoint; //���ܵ�
    protected int attack; //������
    protected int defense; //������
    protected int speed; //��ɫ�ٶ�

    //��������
    public BaseElement stickElement { protected set; get; } //��ǰ����Ԫ�� �涨��ֻ�ܸ���һ��
    protected List<BaseEffeft> effects; //��ǰ����Ч�� buff/debuff

    //ʵ���ƶ�
    protected Vector2 move;

    public void die()
    {
        Destroy(gameObject);
    }

    public void stick(BaseElement element, BaseEntity attacker)
    {
        this.stickElement = element;
        element.Effect(this);
    }

    public bool damage(float point, BaseEntity attacker)
    {
        health -= point;
        if (health <= 0) die();
        return true;
    }


    // Start is called before the first frame update
    void Start()
    {
        this.id = Guid.NewGuid();
        this.nickname = "";
        this.health = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
