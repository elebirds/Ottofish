using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBase : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public Transform playerGroup;
    public Transform enemyGroup;

    // Start is called before the first frame update
    void Start()
    {
        EntityManager.Instance.bs = this;
        EntityManager.Instance.generatePlayer();
        EntityManager.Instance.generateEnemy();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public GameObject generate(GameObject o, Vector3 pos, Transform parent)
    {
        Debug.Log("generate entity" + o + "at" +pos);
        GameObject r = Instantiate(o, pos, Quaternion.identity);
        r.transform.SetParent(parent);
        return r;
    }
}
