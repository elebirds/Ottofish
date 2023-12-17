using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winController : MonoBehaviour
{
    public int Index;
    public TextLoader TextLoader;
    public GameObject player;
    public GameObject panel;
    public GameObject misson;
    private void Update()
    {
        Index = TextLoader.Index;
        if (Index == 2) 
        {
            player.SetActive(true);
        }
        if (Index == 7)
        {
            player.SetActive(false);
        }
        if (Index == 9) 
        {
            player.SetActive(true);
        }
        if(Index == 20) 
        {
            misson.SetActive(true);
            gameObject.SetActive(false);
            panel.SetActive(false);
           
        }
        
    }
}
