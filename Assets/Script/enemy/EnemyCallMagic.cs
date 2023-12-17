using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCallMagic : MonoBehaviour
{
    public GameObject player;
    public GameObject magciPrefab;
    public Transform magicPool;
    public void callmagic() 
    {
        Instantiate(magciPrefab, player.transform.position, Quaternion.identity, magicPool);
        gameObject.SetActive(false);
    }
}
