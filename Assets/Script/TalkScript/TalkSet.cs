using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;
using System.Diagnostics;
using System;
using Unity.VisualScripting;

public class TalkSet : MonoBehaviour
{
    [Header("UI组件")]
    public Text textLabel;
    public Image faceImage;
    public Text textName;

    [Header("文本文件")]
    public TextAsset textFile;
    public int index;
    public float textSpeed;
   

    [Header("头像")]
    public Sprite face01, face02;
    private bool textFinished;
    List<string> textList = new List<string>();

    private void Awake()
    {
        GetTextFormFile(textFile);
        textFinished = true;
    }
    private void OnEnable()
    {
        textLabel.text = textList[index];
        index++;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && index == textList.Count) 
        {
            gameObject.SetActive(false);
            index = 0;
            return;
        }
        if (Input.GetMouseButtonDown(0)&&textFinished) 
        {
            StartCoroutine(SetTextUI());
        }
    }

    void GetTextFormFile(TextAsset file)
    {
        textList.Clear();
        index = 0;
        var lineDate=file.text.Split('\n');
        foreach (var line in lineDate) 
        {
            textList.Add(line);
        }
    }
    IEnumerator SetTextUI()
    {
        textFinished = false;
        textLabel.text = "";
        switch (textList[index].Trim().ToString())
        {
            case "A":
                faceImage.sprite = face01;
                index++;
                break;
            case "B":
                faceImage.sprite = face02;
                index++;
                break;
        }
        for (int a = 0; a < textList[index].Length; a++) 
        {
            textLabel.text += textList[index][a];
            yield return new WaitForSeconds(textSpeed);
        }
        textFinished = true;
        index++;
    }
}

