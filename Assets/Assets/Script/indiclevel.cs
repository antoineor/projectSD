using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class indiclevel : MonoBehaviour
{
    public Text level;
    public PlayerController grille; 
    int levelac;

    void Start()
    {
        TriggerGame.Debut_game += setlevel;
        GrilleButtonScript.game_win += hidelevel;
        GrilleButtonScript.game_lost += hidelevel;
        GrilleButtonScript.levelnondebloque += hidelevel;
        
    }

    void OnDestroy()
    {
        TriggerGame.Debut_game -= setlevel;
        GrilleButtonScript.game_win -= hidelevel;
        GrilleButtonScript.game_lost -= hidelevel;
        GrilleButtonScript.levelnondebloque -= hidelevel;

    }

    public void setlevel()
    {
        if (grille.phase ==0)
        {
            level.text = "Phase 1 \nLevel " + grille.Compteur_Level.ToString();
        }
        
        if (grille.phase ==1)
        {
            levelac = grille.Compteur_Level + 7;
            level.text = "Phase 2 \nLevel " + levelac.ToString();
        }
        
        LeanTween.alphaCanvas(level.GetComponent<CanvasGroup>(), 1f, 1f).setDelay(1f);

    }

    public void hidelevel()
    {
         LeanTween.alphaCanvas(level.GetComponent<CanvasGroup>(), 0f, 1f).setDelay(1f);

    }
}
