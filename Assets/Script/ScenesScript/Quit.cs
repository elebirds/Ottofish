using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public void OnExitGame() 
    {
#if UNITY_EDITOR//在编辑器模式中退出
UnityEditor.EditorApplication.isPlaying = false;
#else//发布后退出
     Application.Quit();
#endif
    }
}
