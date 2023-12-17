using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    public UIBase uib;

    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new UIManager();
            }
            return _instance;
        }
    }
    private UIManager()
    {

    }
}
