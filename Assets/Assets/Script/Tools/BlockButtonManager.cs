using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockButtonManager : MonoBehaviour
{
    public GameObject i;
    // Start is called before the first frame update
    void Start()
    {
        TriggerGame.Debut_game += ToAllow;
        GrilleButtonScript.game_win += ToBlock;
        GrilleButtonScript.game_lost += ToBlock;
        i.SetActive(false);
        


        
    }
    void OnDestroy()
    {
        TriggerGame.Debut_game -= ToAllow;
        GrilleButtonScript.game_win -= ToBlock;
        GrilleButtonScript.game_lost -= ToBlock;
    }

   
    void ToBlock()
    {
        i.SetActive(true);
        
    }
    public void ToAllow()
    {
        i.SetActive(false);
        
    }
}
