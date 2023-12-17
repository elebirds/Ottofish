using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveEvent : Event
{
    public Vector3 from;
    public Vector3 to;

    public PlayerMoveEvent(Vector3 from, Vector3 to) : base("����ƶ��¼�")
    {
        this.to = to;
        this.from = from;
    }
}
