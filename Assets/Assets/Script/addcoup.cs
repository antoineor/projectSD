using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class addcoup : MonoBehaviour
{
    public Button i;
    public GrilleButtonScript grille; 
    public PlayerController player;
    public CoupController coupcontr;
    public EasymodeScript ems;

    void Start()
    {
        TriggerGame.Debut_game += Set_ac;
        GrilleButtonScript.game_win += Hide_ac;
        GrilleButtonScript.game_lost += Hide_ac;
        GrilleButtonScript.levelnondebloque += Hide_ac;
        
    }

    void OnDestroy()
    {
        TriggerGame.Debut_game -= Set_ac;
        GrilleButtonScript.game_win -= Hide_ac;
        GrilleButtonScript.game_lost -= Hide_ac;
        GrilleButtonScript.levelnondebloque -= Hide_ac;

    }

    public void Set_ac()
    {
        i.interactable = true;
        i.GetComponent<CanvasGroup>().blocksRaycasts = true;
        LeanTween.alphaCanvas(i.GetComponent<CanvasGroup>(), 1f, 1f).setDelay(1f);

    }

    public void Hide_ac()
    {
        i.interactable = false;
        i.GetComponent<CanvasGroup>().blocksRaycasts = false;
        LeanTween.alphaCanvas(i.GetComponent<CanvasGroup>(), 0f, 0.1f);
 
        
    }

    public void add_coup()
    
    {
        if (grille.nombre_coup == player.Compteur_Level  || ems.isonEM == 0)
        {
            ColorBlock cb = i.colors;
            cb.normalColor = Color.red;
            i.transform.DOShakePosition(1f, 10f);

        }
        else
        {
            
            grille.nombre_coup = grille.nombre_coup + 1;
            grille.add_coup_grille();
            coupcontr.score_actu();

        }

    }
}
