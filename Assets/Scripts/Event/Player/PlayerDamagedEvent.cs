using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagedEvent : Event
{
    public float damege;
    public GameObject attacker;

    public PlayerDamagedEvent(float damege, GameObject attacker) : base("��������¼�")
    {
        this.damege = damege;
        this.attacker = attacker;
    }
}
