using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBehaviour
{
    public GameObject skillChose;

    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.uib = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
