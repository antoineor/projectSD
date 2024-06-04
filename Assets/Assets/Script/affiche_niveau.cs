using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class affiche_niveau : MonoBehaviour
{
    public GameObject i;
    public Text levelindic;
    public PlayerController grillei; 
    // Start is called before the first frame update
    int levelac;
    public GameObject ph1;
    public GameObject ph2;
    void Start()
    {
        GameManager.OnGameStarted += showlvl;
        // GameManager.OnPresStarted += hidelvl;
        LeanTween.alpha( i , 0f, 0.1f).setEaseInQuart();
        LeanTween.alphaCanvas(i.GetComponent<CanvasGroup>(), 0f, 0.1f);
        transform.LeanMoveZ(-3, 0.5f).setEaseInQuart();
        
    }
    void OnDestroy()
    {
        GameManager.OnGameStarted -= showlvl;
        // GameManager.OnPresStarted -= hidelvl;
    }

    void showlvl()
    {
        if (grillei.phase ==0 && grillei.Compteur_Level < 10)
        {
            ph1.SetActive(true);
            ph2.SetActive(false);
            levelindic.text = "Phase 1 \nLevel " + (grillei.Compteur_Level + 1).ToString();
        }

        if (grillei.phase ==0 && grillei.Compteur_Level == 10)
        {
            ph1.SetActive(false);
            ph2.SetActive(true);
            levelindic.text = "Phase 2 \nLevel " + (grillei.Compteur_Level + 1).ToString();
        }

        
        if (grillei.phase ==1 ) 
        {
            ph2.SetActive(true);
            ph1.SetActive(false);
            levelac = grillei.Compteur_Level + 8;
            levelindic.text = "Phase 2 \nLevel " + levelac.ToString();
        }

        LeanTween.alpha( i , 1f, 0.5f).setEaseInQuart();
        LeanTween.alphaCanvas(i.GetComponent<CanvasGroup>(), 1f, 0.5f);
        LeanTween.alpha( i , 0f, 0.5f).setDelay(1f).setEaseInQuart();
        LeanTween.alphaCanvas(i.GetComponent<CanvasGroup>(), 0f, 0.5f).setDelay(1f);
        // i.interactable = false;
        i.GetComponent<CanvasGroup>().blocksRaycasts = false;

    }

    void hidelvl()
    {
        LeanTween.alpha( i , 0f, 0.5f).setEaseInQuart();
        LeanTween.alphaCanvas(i.GetComponent<CanvasGroup>(), 0f, 0.5f);
    }
    


    

}

