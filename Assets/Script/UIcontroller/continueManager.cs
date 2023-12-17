using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class continueManager : MonoBehaviour
{
    public int Index;
    public TextLoader TextLoader;
    public GameObject player;
    public GameObject bazhuayu;
    private void Update()
    {
        Index = TextLoader.Index; 
        if (Index == 2)
        {
            player.SetActive(true);

        }
        if (Index == 13)
        {
            bazhuayu.SetActive(true);
        }
        if (Index == 24)
        {
            bazhuayu.SetActive(false);
        }
        if (Index == 32)
        {
            player.SetActive(false);
        }
        if (Index == 36)
        {
            player.SetActive(true);
        }
        if (Index == 39)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("PVEScene");
            }
        }
    }

}
