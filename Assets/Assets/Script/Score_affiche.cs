using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Score_affiche : MonoBehaviour
{
    public GameObject i;
    public Button j;
    public int highScore;
    public Text h;
    public PlayerController player;
    public EasymodeScript ems;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        // PlayerPrefs.SetInt("HighScore", 0);
        GrilleButtonScript.game_lost += update_high;
        
        if (PlayerPrefs.HasKey("HighScore"))
            highScore = PlayerPrefs.GetInt("HighScore");
        else
            highScore = 0;
        
        h.text = highScore.ToString();
        
    }

    void OnDestroy()
    {
        GrilleButtonScript.game_lost -= update_high;
    }

    public void Score_affiche_f()
    {
        j.interactable = true;
        j.GetComponent<CanvasGroup>().blocksRaycasts = true;
        // LeanTween.alphaCanvas(j.GetComponent<CanvasGroup>(), 1f, 0.5f) ;
        LeanTween.alphaCanvas(i.GetComponent<CanvasGroup>(), 1f, 0.5f) ;
    }

    public void Score_cache_f()
    {
        j.interactable = false;
        j.GetComponent<CanvasGroup>().blocksRaycasts = false;
        LeanTween.alphaCanvas(i.GetComponent<CanvasGroup>(), 0f, 0.5f);
    }

    public void update_high()
    
    {
        if (player.Compteur_Level - 1 > highScore & ems.isonEM == 0)
        {
            if (player.phase == 0 )
            {
                highScore = player.Compteur_Level - 1;
            }
            if (player.phase == 1 )
            {
                highScore = player.Compteur_Level + 7;
            }
            
            h.text = highScore.ToString();
            PlayerPrefs.SetInt("HighScore", highScore);

        }

    }



}
