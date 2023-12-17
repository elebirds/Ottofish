using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class showmiaoshu : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    public GameObject miaoshu;
    public void OnPointerEnter(PointerEventData eventData)
    {
        miaoshu.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        miaoshu.SetActive(false);   
    }
}
