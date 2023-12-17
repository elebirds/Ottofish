using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCallMagic : MonoBehaviour
{
    public static int sp;
    public static int maxSp;
    public GameObject spbox;
    private void Start()
    {
        maxSp = 2;
        sp = maxSp;
        spbox.SetActive(true);

        EventManager.AddListener<StateChangeEvent>((state) =>
        {
            if (state.newState == State.PLAYER_ATTACK)
            {
                UIManager.Instance.uib.skillChose.SetActive(true);
            }
            if (state.oldState == State.PLAYER_ATTACK)
            {
                UIManager.Instance.uib.skillChose.SetActive(false);
            }
        });
    }
    private void Update()
    {
        
    }
    public void turnFinish() 
    {
        sp = maxSp;
    }
    
}
