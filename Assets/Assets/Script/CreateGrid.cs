using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System;

public class PlayerController : MonoBehaviour
{

    // bool isReady;
    // bool isDead;
    public GameObject i;
    public int Compteur_Level = 0; 
    static public int[,] matrice_grid = new int[5, 5];
   
    public int e;
    static public event Action fin_creation_matrice;

    public List<List<int>> coups;
    public List<List<int>> toutcoups;
    public List<int> compteurcoup;
    public List<int> coup;
    public int phase = 0;
    public TriggerGame trigg;
    public int levelmain = 0;
    

    void Start()
    {
        coup = new List<int>();
        coups = new List<List<int>>();
        toutcoups = new List<List<int>>();
        


        GameManager.OnGameStarted += OnGameStarted;
        GameManager.OnPresStarted += OnPresStarted;
        TriggerGame.Debut_game += grillehaut;
        GrilleButtonScript.game_lost += fade;
        
        

    }

    void OnDestroy()
    {
        GameManager.OnGameStarted -= OnGameStarted;
        GameManager.OnPresStarted -= OnPresStarted;
        TriggerGame.Debut_game -= grillehaut;
        GrilleButtonScript.game_lost -= fade;
        
    }
    void fade()
    {
        
        LeanTween.alpha( i , 0f, 0.5f).setDelay(3.65f).setEaseInQuart();
        // transform.LeanMoveY(-1, 1f);
    }

    void restart_grid()
    {
        Compteur_Level = 0;
        phase = 0;
        levelmain = 0;
        LeanTween.alpha( i , 0f, 0.5f).setEaseInQuart();
        // transform.LeanMoveY(-1, 1f);
    }

    void OnGameStarted()
    {
        if (GameManager.Instance.mode == 0)
        {

            transform.LeanMoveX(-0.47f, 1f);
            transform.LeanMoveY(3.75f, 1f);
            LeanTween.scale(i,new Vector3(0.7f,0.7f,0.7f) , 1f);

        }
        // LeanTween.alpha( i , 0f, 0.2f);
        // transform.LeanMove(new Vector2(-0.67f, 1), 1f);
        if (GameManager.Instance.mode == 1)
        {
            transform.LeanMoveX(-0.67f, 1f);
            transform.LeanMoveY(1, 1f);
            LeanTween.scale(i,new Vector3(1,1,1) , 1f);
    
        }
       
        
        // transform.LeanMoveLocal(new Vector2(0, 5000), 1).setEaseInQuart();
        
    }

    void grillehaut()
    {
        if (GameManager.Instance.mode == 1)
        {
            LeanTween.scale(i, new Vector3(0.4f,0.4f,0.4f), 1.5f).setEaseInQuart();
            transform.LeanMove(new Vector2(0.01f, 1), 1.5f);
            transform.LeanMove(new Vector2(-0.13f, 4.74f), 1.5f).setEaseInQuart();
        }
    }

    void OnPresStarted()
    {
        levelmain = levelmain + 1;
        Compteur_Level = Compteur_Level + 1 ;
        if (Compteur_Level == 11 & phase == 0)
        {
            phase+=1;
            Compteur_Level=3;

        }

    


        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                matrice_grid[i, j] = 0;
            }
        }

        // List<int> coups = new List<int>();
        // for (int i = 0; i < 2*Compteur_Level; i++)
        // {
        //     int coup = UnityEngine.Random.Range(0, 5); 
        //     coups.Add(coup);
        // }

        coups.Clear();
        toutcoups.Clear();
        compteurcoup = new List<int>(new int[25]);
        for (int i = 0; i < compteurcoup.Count; i++)
        {
            compteurcoup[i] = 0;
        }

        // for (int n = 0; n < phase; n++) 
        // {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    coup = new List<int>();
                    coup.Add(i);
                    coup.Add(j);
                    toutcoups.Add(coup);
                } 
            }

        // }
        

        for (int i = 0; i < Compteur_Level; i++)
        {
            int coup_chois = UnityEngine.Random.Range(0, toutcoups.Count- 1); 
            coups.Add(toutcoups[coup_chois]);
            compteurcoup[coup_chois] = compteurcoup[coup_chois] + 1;
            if (compteurcoup[coup_chois] == phase + 1)
            {
                toutcoups.RemoveAt(coup_chois);
                compteurcoup.RemoveAt(coup_chois);
            }
            

        }


        

        for (int i = 0; i < Compteur_Level; i++)
        {
            // test = coups[0];
            // test2 = coups[1];
            // test3 = coups[2];
            // test4 = coups[3];

            coups_place(coups[i][0], coups[i][1]);

            // coups_place(coups[2*i], coups[2*i+1]);
            
             
        }

      

        LeanTween.alpha( i , 1f, 1f).setDelay(1f).setEaseInQuart();
        fin_creation_matrice?.Invoke();
        trigg.invoke_deb();
        

        
        

    }

    void coups_place(int a, int b)
    {   
        matrice_grid[a, b] =  (matrice_grid[a, b] + 1) % (phase + 2) ;

        if (a < 4 )
        {
            matrice_grid[a+1, b] = ( matrice_grid[a+1, b] + 1 ) % (phase + 2);
            if(b<4)
            {
                matrice_grid[a+1, b+1] = ( matrice_grid[a+1, b+1]+ 1 ) % (phase + 2);
            }
            if(b>0)
            {
                matrice_grid[a+1, b-1] = ( matrice_grid[a+1, b-1]+ 1 ) % (phase + 2);
            }
        }
        if (b < 4 )
        {
            matrice_grid[a, b+1] = ( matrice_grid[a, b+1]+ 1 ) % (phase + 2);
            if(a>0)
            {
                matrice_grid[a-1, b+1] = ( matrice_grid[a-1, b+1] + 1) % (phase + 2);
            }
        }
        if (a > 0 )
        {
            matrice_grid[a-1, b] = ( matrice_grid[a-1, b]+ 1 ) % (phase + 2);
            if(b>0)
            {
                matrice_grid[a-1, b-1] = ( matrice_grid[a-1, b-1] + 1) % (phase + 2);
            }
        }

        if (b > 0 )
        {
            matrice_grid[a, b-1] = ( matrice_grid[a, b-1] + 1) % (phase + 2);
        }

    }
    



}

