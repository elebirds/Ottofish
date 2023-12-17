using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBase : MonoBehaviour
{
    public Transform mapGlobal;
    public Transform entityGlobal;
    public GameObject blockPrefab;
    public GameObject obstaclePrefab;

    // Start is called before the first frame update
    void Start()
    {
        MapManager.Instance.mapBase = this;
        MapManager.Instance.init();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject generate(GameObject o,Vector3 pos)
    {
        GameObject r = Instantiate(o, pos, Quaternion.identity);
        r.transform.SetParent(mapGlobal);
        return r;
    }
}
