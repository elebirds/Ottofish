using System.Collections.Generic;
using UnityEngine;

//地图方格管理
public class MapManager
{
    public MapBase mapBase;
    public int RowCount;//地图行
    public int ColCount;//地图列
    public Dictionary<string, Block> Blocks;
    private Dictionary<string, GameObject> prefabs;

    public void init()
    {
        RowCount = 32;
        ColCount = 18;
        this.Blocks = new Dictionary<string, Block>();
        this.generate();
    }

    public void generate()
    {
        for (int i = 1; i <= RowCount; i++)
        {
            for (int j = 1; j <= ColCount; j++)
            {
                Vector3 pos = transformPosition(i,j);
                Block b = mapBase.generate(mapBase.blockPrefab, pos).GetComponent<Block>();
                b.X = i;
                b.Y = j;
                Blocks[i+","+j] = b;
                //Debug.Log("gen" + i + j);
                if (i == 1 || i == RowCount || j == 1 || j == ColCount) this.addObstacle(i, j);
            }
        }
        //Debug.Log(Blocks.Count);
    }

    public void addObstacle(int x,int y)
    {
        Vector3 pos = transformPosition2(x,y);
        mapBase.generate(mapBase.obstaclePrefab, pos);
        Blocks[x+","+y].canCross = false;
    }

    private static MapManager _instance;
    public static MapManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new MapManager();
            }
            return _instance;
        }
    }
    private MapManager() { }

    public static Vector3 transformPosition(int x, int y)//中心
    {
        return new(-0.32f + (x * 0.64f), -0.32f + (y * 0.64f), 0);
    }

    public static Vector3 transformPosition1(int x, int y)//左下
    {
        return new(-0.64f + (x * 0.64f), -0.64f + (y * 0.64f), 0);
    }
    public static Vector3 transformPosition2(int x, int y)
    {
        return new((x * 0.64f), -0.64f + (y * 0.64f), 0);
    }
    public static Vector3 transformPosition3(int x, int y)//右上
    {
        return new((x * 0.64f), (y * 0.64f), 0);
    }
    public static Vector3 transformPosition4(int x, int y)//人物
    {
        return new((x * 0.64f), -0.32f + (y * 0.64f), 0);
    }
}
