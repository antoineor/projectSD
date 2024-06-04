using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TriggerGame : MonoBehaviour

{
    static public event Action Debut_game;

    void OnTriggerEnter(Collider other)
    {
        if (GameManager.Instance.mode == 1)
        {
       
            Debut_game?.Invoke();
        }
   

    }

    public void invoke_deb()
    {
        Debut_game?.Invoke();
    }
}

