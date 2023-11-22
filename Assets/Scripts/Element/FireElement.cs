
using System;

public class FireElement : BaseElement
{
    public FireElement(int amount, BaseEntity attacker = null) : base(ElementType.FIRE, amount, attacker)
    {
    }

    public override void Effect(BaseEntity e)
    {
        
    }

    public override void React(BaseEntity e)
    {
        if(e == null) return;
        if(e.stickElement.type == ElementType.ICE)// 融化反应
        {
            e.damage(Math.Min(amount,e.stickElement.amount)*2,this.attacker);
        }
    }
}