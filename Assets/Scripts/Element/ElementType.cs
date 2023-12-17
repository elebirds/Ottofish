public class ElementType
{
    public int type { get; private set; }
    public string name { get; private set; }
    public bool stick { get; private set; }

    public ElementType(int type, string name, bool stick)
    {
        this.type = type;
        this.name = name;
        this.stick = stick;
    }

    public readonly static ElementType PHYSICS = new ElementType(0, "物理", false);
    public readonly static ElementType FIRE = new ElementType(1, "火", true);
    public readonly static ElementType ICE = new ElementType(2, "冰", true);
    public readonly static ElementType THUNDER = new ElementType(3, "雷", true);
    public readonly static ElementType FLORA = new ElementType(4, "草", true);
    public readonly static ElementType PSIONIC = new ElementType(5, "超能", true);
}