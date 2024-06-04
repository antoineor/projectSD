using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class CoupController : MonoBehaviour
{
    public GrilleButtonScript grille; 
    public Text scoret;
    

    // Start is called before the first frame update
    void Start()
    {
        TriggerGame.Debut_game += Set_score;
        GrilleButtonScript.game_win += Hide_score;
        GrilleButtonScript.game_lost += Hide_score;
        GrilleButtonScript.levelnondebloque += Hide_score;
        
    }

    void OnDestroy()
    {
        TriggerGame.Debut_game -= Set_score;
        GrilleButtonScript.game_win -= Hide_score;
        GrilleButtonScript.game_lost -= Hide_score;
        GrilleButtonScript.levelnondebloque -= Hide_score;

    }

    public void Set_score()
    {
         LeanTween.alphaCanvas(scoret.GetComponent<CanvasGroup>(), 1f, 1f).setDelay(1f);

    }

    public void Hide_score()
    {
         LeanTween.alphaCanvas(scoret.GetComponent<CanvasGroup>(), 0f, 1f).setDelay(1f);

    }

    public void score_actu()
    {
        
        scoret.text = grille.nombre_coup.ToString();
        scoret.transform.DOPunchScale(Vector3.one * 0.15f, 0.2f);

        
        
    }
}
