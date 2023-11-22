using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEntity : MonoBehaviour{
    //基本信息
    protected Guid id;
    protected string nickname;

    //属性
    protected float health; //血量
    protected float shield; //护盾值
    protected List<ElementType> weaknesses; //护盾弱点
    protected int skillPoint; //技能点
    protected int attack; //攻击力
    protected int defense; //防御力
    protected int speed; //角色速度

    //附加属性
    public BaseElement stickElement { protected set; get; } //当前附着元素 规定：只能附着一种
    protected List<BaseEffeft> effects; //当前附着效果 buff/debuff

    //实体移动
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
