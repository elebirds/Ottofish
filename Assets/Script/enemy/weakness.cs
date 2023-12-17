using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weakness : MonoBehaviour
{
    public Slider sli;
    public Character owner;
    public GameObject follow;
    private void Start()
    {
        owner = owner.GetComponent<Character>();
    }
    private void Update()
    {
        //sli.maxValue =owner.weakness;
        //li.value=owner.currentWeakness;
        Vector2 hpboxfollow = Camera.main.WorldToScreenPoint(follow.transform.position);
        sli.GetComponent<RectTransform>().position = hpboxfollow;
    }
}
