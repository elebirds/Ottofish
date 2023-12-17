using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextRoundEvent : Event
{
    public int oldRound;
    public int newRound;

    public NextRoundEvent(int oldRound, int newRound) : base("��һ�غ��¼�")
    {
        this.oldRound = oldRound;
        this.newRound = newRound;
    }
}
