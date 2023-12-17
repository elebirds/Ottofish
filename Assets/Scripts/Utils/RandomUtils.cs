using UnityEngine;
using Unity.Mathematics;

public static class RandomUtils
{
    public static int randomOne()
    {
        int r = UnityEngine.Random.Range(-10, 10);
        if (r == 0) return 1;
        return r / math.abs(r);
    }

    public static Color randomColor()
    {
        switch (UnityEngine.Random.Range(0, 8)) { 
            case 0: return Color.white;
            case 1: return Color.green;
            case 2: return Color.blue;
            case 3: return Color.magenta;
            case 4: return Color.red;
            case 5: return Color.yellow;
            case 6: return Color.cyan;
            case 7: return Color.grey;
            case 8:
            default: return Color.gray;
        }
    }
}
