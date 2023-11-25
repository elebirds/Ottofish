public class ElementType{
    public int type { get; private set; }
    public string name { get; private set; }
    public bool stick { get; private set; }

    public ElementType(int type, string name, bool stick)
    {
        this.type = type;
        this.name = name;
        this.stick = stick;
    }

    public readonly static ElementType PHYSICS = new ElementType(0, "ÎïÀí", false);
    public readonly static ElementType FIRE = new ElementType(1, "»ð", true);
    public readonly static ElementType ICE = new ElementType(2, "±ù", true);
    public readonly static ElementType THUNDER = new ElementType(3, "À×", true);
    public readonly static ElementType FLORA = new ElementType(4, "²Ý", true);
    public readonly static ElementType PSIONIC = new ElementType(5, "³¬ÄÜ", true);
}