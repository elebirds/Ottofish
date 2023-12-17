using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp : MonoBehaviour
{
    public Slider sli;
    public Character owner;
    public GameObject follow;
    void Start()
    {
        owner = owner.GetComponent<Character>();   
    }

    // Update is called once per frame
    void Update()
    {
        sli.maxValue = owner.maxHealth;
        sli.value = owner.currentHealth;
        Vector2 hpboxfollow = Camera.main.WorldToScreenPoint(follow.transform.position);
        sli.GetComponent<RectTransform>().position = hpboxfollow;
    }
}
