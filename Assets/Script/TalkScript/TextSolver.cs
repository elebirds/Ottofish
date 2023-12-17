using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSolver : MonoBehaviour
{
    [SerializeField] private TextAsset GameScript;
    public List<string> phrase;
    private void Awake()
    {
        phrase = new List<string>();
        string tempContent=GameScript.ToString();
        string[] splitRes = tempContent.Split('\n');
        foreach (var child in splitRes) 
        {
            if (child.StartsWith("//") || child.Equals(string.Empty))
            {
                continue;
            }
            phrase.Add(child.Substring(0, child.Length-1));
        }
    }
}
