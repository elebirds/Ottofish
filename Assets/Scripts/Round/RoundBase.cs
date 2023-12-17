using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundBase : MonoBehaviour
{
    public void nextState()
    {
        RoundManager.Instance.nextState();
    }

    // Start is called before the first frame update
    void Start()
    {
        RoundManager.Instance.init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
