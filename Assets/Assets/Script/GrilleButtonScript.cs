using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GrilleButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject grilleb;
    static public int[,] button_grid = new int[5, 5];
    public int compteur_result;
    public int nombre_coup;
    static public event Action coup_joue;

    static public event Action game_win;
    static public event Action game_lost;
    static public event Action levelnondebloque;
    public CoupController coupcontrol;
    public PlayerController player;
    public int check_victoire;
    public int memx;
    public int memy;
    public List<int> coupsjouegamex ;
    public List<int> coupsjouegamey ;
    public int niveauactuel;
    public int highScore;
    public EasymodeScript ems;

    void Start()
    

    {
        
        TriggerGame.Debut_game += Partie_lancee;
        
        
    }

    void OnDestroy()
    {
        TriggerGame.Debut_game -= Partie_lancee;
    
    }

    void Partie_lancee()
    {
        
        
        coupsjouegamex.Clear();
        coupsjouegamey.Clear();
        check_victoire = 0;
        nombre_coup = player.Compteur_Level;
        coupcontrol.score_actu();
        compteur_result = 0;

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                button_grid[i, j] = 0;
            }
        }

    }



    public void add_coup_grille()
    {
        Boutonpresse(coupsjouegamex[coupsjouegamey.Count - 1],coupsjouegamey[coupsjouegamey.Count - 1],1);
        coupsjouegamex.RemoveAt(coupsjouegamex.Count - 1);
        coupsjouegamey.RemoveAt(coupsjouegamey.Count - 1);

    }

    public void Boutonpresse(int a, int b, int c)
    {
        if (c ==0)
        {
            coupsjouegamex.Add(a);
            coupsjouegamey.Add(b);

        
            nombre_coup = nombre_coup - 1;
            coupcontrol.score_actu();

            button_grid[a, b] = (button_grid[a, b] + 1 ) % (player.phase + 2);

        

        if (a < 4 )
        {
            button_grid[a+1, b] = (button_grid[a+1, b] + 1 ) % (player.phase + 2);
            if(b<4)
            {
                button_grid[a+1, b+1] = (button_grid[a+1, b+1] + 1 ) % (player.phase + 2);
            }
            if(b>0)
            {
                button_grid[a+1, b-1] = (button_grid[a+1, b-1] + 1 ) % (player.phase + 2);
            }
        }
        if (b < 4 )
        {
            button_grid[a, b+1] = (button_grid[a, b+1] + 1 ) % (player.phase + 2);
            if(a>0)
            {
                button_grid[a-1, b+1] = (button_grid[a-1, b+1] + 1 ) % (player.phase + 2);
            }
        }
        if (a > 0 )
        {
            button_grid[a-1, b] = (button_grid[a-1, b] + 1 ) % (player.phase + 2);
            if(b>0)
            {
                button_grid[a-1, b-1] = (button_grid[a-1, b-1] + 1 ) % (player.phase + 2);
            }
        }

        if (b > 0 )
        {
            button_grid[a, b-1] = (button_grid[a, b-1] + 1 ) % (player.phase + 2);
        }
        coup_joue?.Invoke();

        compteur_result = 0;
        for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (button_grid[i, j] == PlayerController.matrice_grid[i,j])
                    {
                        compteur_result = compteur_result + 1;

                    }
                }
            }
            if (compteur_result==25)
            {
                if (PlayerPrefs.HasKey("HighScore"))
                    highScore = PlayerPrefs.GetInt("HighScore");
                else
                    highScore = 0;

                if (player.levelmain + 1 <= highScore || ems.isonEM == 0 )
                    game_win?.Invoke();
                else 
                    levelnondebloque?.Invoke();
                // if (player.phase ==1)
                // {
                //     niveauactuel = player.Compteur_Level - 1;
                // }
                // if (player.phase ==2)
                // {
                //     niveauactuel = player.Compteur_Level + 7 ;
                // }
                
                
                // GameManager.Instance.mnv[niveauactuel] = GameManager.Instance.mnv[niveauactuel] + 1 ;


                // PlayerPrefs.SetInt("niveaucomplete", GameManager.Instance.mnv);

            }
            else
            {
                if (nombre_coup==0)
                {
                    game_lost?.Invoke();
                }
                

            }
        }
        
        
        
        else {

        button_grid[a, b] = (button_grid[a, b] + player.phase + 1 ) % (player.phase + 2);

        

        if (a < 4 )
        {
            button_grid[a+1, b] = (button_grid[a+1, b] + player.phase + 1) % (player.phase + 2);
            if(b<4)
            {
                button_grid[a+1, b+1] = (button_grid[a+1, b+1] + player.phase + 1 ) % (player.phase + 2);
            }
            if(b>0)
            {
                button_grid[a+1, b-1] = (button_grid[a+1, b-1] + player.phase + 1 ) % (player.phase + 2);
            }
        }
        if (b < 4 )
        {
            button_grid[a, b+1] = (button_grid[a, b+1] + player.phase + 1 ) % (player.phase + 2);
            if(a>0)
            {
                button_grid[a-1, b+1] = (button_grid[a-1, b+1] + player.phase + 1 ) % (player.phase + 2);
            }
        }
        if (a > 0 )
        {
            button_grid[a-1, b] = (button_grid[a-1, b] + player.phase + 1 ) % (player.phase + 2);
            if(b>0)
            {
                button_grid[a-1, b-1] = (button_grid[a-1, b-1] + player.phase + 1 ) % (player.phase + 2);
            }
        }

        if (b > 0 )
        {
            button_grid[a, b-1] = (button_grid[a, b-1] + player.phase + 1 ) % (player.phase + 2);
        }
        coup_joue?.Invoke();
        

        }
    }
}


// public void check_defaite()
// {
//     chance_restante = chance_restante - 1 
//     if chance

// } 


