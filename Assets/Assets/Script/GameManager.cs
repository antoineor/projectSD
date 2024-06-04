using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance;

    static public event Action OnGameStarted;
    static public event Action OnGameEnded;
    static public event Action OnPresStarted;
    static public event Action choixniveau;
    public int mode;
    public EasymodeScript ES;
    public GameObject tableauchoix;
    public PlayerController gridc;
    public List<int> mnv;

    public enum GameState
    {
        Easy,
        Medium,
        Hard,
    }

    public GameState CurrentGameState;


    void Awake()
    {
        Instance = this;

        Application.targetFrameRate = 60;
    }

    void Start()
    {
        GrilleButtonScript.game_win += gamesuiv;
    
        
    }

    void OnDestroy()
    {
        GrilleButtonScript.game_win -= gamesuiv;
     
    }



    public void StartGame()
    {
        if (ES.isonEM == 1 && gridc.Compteur_Level == 0 )
        {
            choix_niveau();
        }

        else 
        {
            OnGameStarted?.Invoke();
            OnPresStarted?.Invoke();
        }
    }

    public void startonlevel(int a, int b)
    {
        gridc.levelmain = b - 1 ;
        if (a==1)
        {
            gridc.phase = a -1 ;
            gridc.Compteur_Level = b - 1;
        }
        if (a==2 )
        {
            gridc.phase = a-1;
            gridc.Compteur_Level = b - 8;

        }

        OnGameStarted?.Invoke();
        OnPresStarted?.Invoke();
    }


    public void choix_niveau()
    {
        LeanTween.alphaCanvas(tableauchoix.GetComponent<CanvasGroup>(), 1f, 0.5f) ;
        choixniveau?.Invoke();

    }

    public void GameOver()
    {
    
        // CameraController.Instance.Shake(0.3f, 0.25f);
        OnGameEnded?.Invoke();

    }

    public void RestartGame()
    {
        SceneManager.LoadSceneAsync(0);
    }


    void gamesuiv()
    {
      Invoke("InfoGamesuivante", 3f);
    }


    void InfoGamesuivante()
    {
        StartGame();

    }

}