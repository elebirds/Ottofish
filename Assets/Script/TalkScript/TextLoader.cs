using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextLoader : MonoBehaviour
{
    public TextSolver solver;
    public TW_MultiStrings_Regular tWregular;
    public Text SpeakerName;
    public int Index=0;
   
    private void Start()
    {
        solver = GetComponent<TextSolver>();
    }
    private void Update()
    {
        if (Index == 0)
        {
            Push();
            Index++;
        }
        if (Input.GetMouseButtonDown(0)&&Index<solver.phrase.Count-1)
        {
            Push();
            Index++;
        }
        
    }
    private void Push() 
    {
        
        Regex regName = new Regex(".*?(?=¡¾)");
        Match name = regName.Match(solver.phrase[Index]);
        Regex resContent = new Regex("(?<=¡¾).*?(?=¡¿)");
        Match content = resContent.Match(solver.phrase[Index]);
        if (content.Success)
        {
            if (name.Success)
            {
                SpeakerName.text = name.Value;
            }
            tWregular.MultiStrings[0]=content.Value;
            tWregular.NextString();
        }
        if (solver.phrase[Index].StartsWith("show")) 
        {
            if (solver.phrase[Index].Contains("="))
            {
                string[] posMes = solver.phrase[Index].Split("-")[1].Split("=");
                CommandScript.Instance.ShowImage(posMes[0],
                    float.Parse(posMes[1].Split(' ')[0]),
                    float.Parse(posMes[1].Split(' ')[1]));
            }
            else
            {
                CommandScript.Instance.ShowImage(solver.phrase[Index].Split('-')[1]);
            }
            Index++;
            Push();
        }
        
    }
}
