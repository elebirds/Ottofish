using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceUpdater : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (!SkillManager.Instance.bs.isPreparing) return;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = mousePos;
    }
}
