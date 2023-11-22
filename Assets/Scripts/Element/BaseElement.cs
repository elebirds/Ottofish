using System.ComponentModel;

public abstract class BaseElement{
    [Description("元素类型")]
    public ElementType type { get; protected set; }

    [Description("元素量")]
    public int amount { get; protected set; }

    [Description("攻击者")]
    public BaseEntity attacker { get; protected set; }

    public BaseElement(ElementType type, int amount, BaseEntity attacker = null)
    {
        this.type = type;
        this.amount = amount;
        this.attacker = attacker;
    }

    public abstract void React(BaseEntity e);

    public abstract void Effect(BaseEntity e);
}
