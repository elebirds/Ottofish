using System.Collections.Generic;
using UnityEngine;

public class EntityManager
{
    public EntityBase bs;
    public GameObject player;
    public PlayerMoveControl playerMove;

    public List<GameObject> entities;
    public Dictionary<int, GameObject> enemies;
    public Dictionary<int, EnemyMoveControl> enemyMoves;
    public List<GameObject> deads;

    public static int spawnX = 10, spawnY = 10;
    public int enemyCount = 4;
    public int activeEnemyCount = 4;

    public void generatePlayer()
    {
        Vector3 pos = MapManager.transformPosition(spawnX, spawnX);
        player = bs.generate(bs.player, pos,bs.playerGroup);
        playerMove = player.GetComponent<PlayerMoveControl>();
        entities.Add(player);
    }

    public void generateEnemy()
    {
        //boss、小怪生成
        for(int i = 1; i <= enemyCount; i++)
        {
            Vector3 pos = MapManager.transformPosition(spawnX, spawnX);
            pos += new Vector3(RandomUtils.randomOne()*Random.Range(0.8f, 2.7f), RandomUtils.randomOne() * Random.Range(0.8f, 2.7f));
            GameObject e = bs.generate(bs.enemy, pos,bs.enemyGroup);
            enemies[i] = e;
            EnemyMoveControl mc = e.GetComponent<EnemyMoveControl>();
            mc.id = i;
            mc.isBoss = i == 1;
            enemyMoves[i] = mc;
            entities.Add(e);
        }
        EventManager.AddListener<StateChangeEvent>((evt) => {
            if (evt.newState != State.MONSTER_MOVE) return;
            EnemyMoveControl.moveCount = 0;
            foreach (var mc in enemyMoves)
            {
                mc.Value.move();
            }
        }, EventPriority.MONITOR);//怪物移动监听
        EventManager.AddListener<StateChangeEvent>((evt) => {
            if (evt.newState != State.MONSTER_ATTACK) return;
            EnemyMoveControl.attackCount = 0;
            foreach (var mc in enemyMoves)
            {
                mc.Value.attack();
            }
        }, EventPriority.MONITOR);//怪物攻击监听
    }

    private static EntityManager _instance;
    public static EntityManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new EntityManager();
            }
            return _instance;
        }
    }
    private EntityManager()
    {
        this.entities = new List<GameObject>();
        this.enemies = new Dictionary<int, GameObject>();
        this.enemyMoves = new Dictionary<int, EnemyMoveControl>();
        this.deads = new List<GameObject>();
    }
}
