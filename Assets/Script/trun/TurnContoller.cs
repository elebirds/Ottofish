using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnContoller:MonoBehaviour
{
    public static int turn = 0;
    private void Start()
    {
        turn = 2;
    }
    public void plus() 
    {
        turn++;
    }
}
