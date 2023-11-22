using System.ComponentModel;

public abstract class BaseElement{
    [Description("Ԫ������")]
    public ElementType type { get; protected set; }

    [Description("Ԫ����")]
    public int amount { get; protected set; }

    [Description("������")]
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
