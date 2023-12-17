using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChangeEvent : Event
{
    public State oldState;
    public State newState;

    public StateChangeEvent(State origin, State target) : base("״̬�ı��¼�")
    {
        this.oldState = origin;
        this.newState = target;
    }

    public override string ToString() {
        return base.ToString() + " oldState:" + oldState.ToString() +" newState:" + newState.ToString();
    }
}
