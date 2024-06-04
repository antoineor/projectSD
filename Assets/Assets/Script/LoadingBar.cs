using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingBar : MonoBehaviour
{
    public GameObject i;
    public GameObject j;
    public GameObject k;

    void Start()
    {
        PlayerController.fin_creation_matrice += Loading;
        TriggerGame.Debut_game += fin_grille;

    }

    void OnDestroy()
    {
        PlayerController.fin_creation_matrice -= Loading;
    }
    void Loading()
    {
        if (GameManager.Instance.mode == 1)
        {

            LeanTween.alpha( k , 1f, 0.1f).setDelay(3f);
            
            LeanTween.alpha( j , 1f, 0.5f).setDelay(3f);

            LeanTween.scaleX(i, 4.8f, 10f).setDelay(3f);
        }
    }

    public void skip()
    {
        
            LeanTween.cancel(i);
            LeanTween.scaleX(i, 4.8f, 1f);


        
        
    }

    void fin_grille()
    {
        LeanTween.alpha( k , 0f, 0.5f).setDelay(1f);
        LeanTween.scaleX(i, 0f, 0.1f).setDelay(5f);
   
    }



}
