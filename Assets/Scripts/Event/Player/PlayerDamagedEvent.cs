using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagedEvent : Event
{
    public float damege;
    public GameObject attacker;

    public PlayerDamagedEvent(float damege, GameObject attacker) : base("玩家受伤事件")
    {
        this.damege = damege;
        this.attacker = attacker;
    }
}
