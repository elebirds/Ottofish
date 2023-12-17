using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager
{
    public int round {  get; private set; }

    public State state { get; private set; }

    public void init()
    {
        round = 1;
        state = State.PLAYER_MOVE;
    }

    public void nextState()
    {
        state++;
        EventManager.Broadcast(new StateChangeEvent(state - 1, state));
        if (state == State.SETTLEMENT)
        {
            if (!this.checkFinal())
            {
                round++;
                EventManager.Broadcast(new StateChangeEvent(state, State.PLAYER_MOVE));
                EventManager.Broadcast(new NextRoundEvent(round - 1, round));
                state = State.PLAYER_MOVE;
            }
        }
    }

    public bool checkFinal()
    {
        return false;
    }

    private static RoundManager _instance;
    public static RoundManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new RoundManager();
            }
            return _instance;
        }
    }
    private RoundManager() { }
}
