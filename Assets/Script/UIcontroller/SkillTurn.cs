using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTurn : MonoBehaviour
{
    // Start is called before the first frame update
    public int currentTurn;
    public GameObject skillrange;
    public int turn;
    private void Start()
    {
        currentTurn = TurnContoller.turn;
       
    }

    // Update is called once per frame
    void Update()
    {
        //skillrange.SetActive(true);
        //turn = TurnContoller.turn;
        //if (currentTurn == TurnContoller.turn)
        //{
        //    skillrange.SetActive(true);
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        currentTurn++;
        //    }
        //}
        //else 
        //{
        //    skillrange.SetActive(false);
        //}
    }
}
