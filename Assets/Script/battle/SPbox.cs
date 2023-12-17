using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SPbox : MonoBehaviour
{
    public Slider sli;
    public GameObject follow;
    // Update is called once per frame

    private void Start()
    {
        EventManager.AddListener<NextRoundEvent>((evt) =>
        {
            playerCallMagic.sp = playerCallMagic.maxSp;
        });
    }

    void Update()
    {
        sli.maxValue = playerCallMagic.maxSp;
        sli.value = playerCallMagic.sp;
        Vector2 hpboxfollow = Camera.main.WorldToScreenPoint(follow.transform.position);
        sli.GetComponent<RectTransform>().position = hpboxfollow;
    }
}
