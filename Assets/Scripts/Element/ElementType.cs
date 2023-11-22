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

    public static ElementType PHYSICS = new ElementType(0, "ÎïÀí", false);
    public static ElementType FIRE = new ElementType(1, "»ð", true);
    public static ElementType ICE = new ElementType(2, "±ù", true);
    public static ElementType THUNDER = new ElementType(3, "À×", true);
    public static ElementType FLORA = new ElementType(4, "²Ý", true);
    public static ElementType PSIONIC = new ElementType(5, "³¬ÄÜ", true);
}
