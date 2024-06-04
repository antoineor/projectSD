using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonScript : MonoBehaviour
{
     
    public Button i;
    public Color targetColor;
    public int a;
    public int b;
    public GrilleButtonScript grillo;
    public Color wincolor;
    public Color lostcolor;
    public Color normalcolor;
    public Rigidbody2D rb;
    public Color p2color;
  


    void Start()
    {
        
        // i.SetActive(false);
        i.interactable = false;
        i.GetComponent<CanvasGroup>().blocksRaycasts = false;
        TriggerGame.Debut_game += Set_button;
        GrilleButtonScript.coup_joue += CheckSwitch;
        GrilleButtonScript.game_win += Game_win_but;
        GrilleButtonScript.game_lost += Game_lost_but;
        GrilleButtonScript.levelnondebloque += Game_win_but;

        
    }

    void OnDestroy()
    {
        TriggerGame.Debut_game -= Set_button;
        GrilleButtonScript.coup_joue -= CheckSwitch;
        GrilleButtonScript.game_win -= Game_win_but;
        GrilleButtonScript.game_lost -= Game_lost_but;
        GrilleButtonScript.levelnondebloque -= Game_win_but;
    }

    public void bouton_presse()
    {
        grillo.Boutonpresse(a,b,0);
        
   
    }


    public void CheckSwitch()
    {
        if (GrilleButtonScript.button_grid[a,b]==0)
        {
            targetColor = normalcolor; 
            LeanTween.color(i.image.rectTransform, targetColor,0.5f).setOnUpdate((Color color) => { i.image.color = color; }); 
        }

        if (GrilleButtonScript.button_grid[a,b]==1)
        {
            targetColor = Color.black; 
            LeanTween.color(i.image.rectTransform, targetColor,0.5f).setOnUpdate((Color color) => { i.image.color = color; }); 
        }

        if (GrilleButtonScript.button_grid[a,b]==2)
        {
            targetColor = Color.black; 
            LeanTween.color(i.image.rectTransform, p2color,0.5f).setOnUpdate((Color color) => { i.image.color = color; }); 
        }

    }
    
    // public void Switch_color()
    // {   

    //     if (i.image.color == Color.black)
    //     {
    //         targetColor = Color.white; 
    //     }
    //     if (i.image.color == Color.white)
    //     {
    //         targetColor = Color.black;
    //     }

    //     LeanTween.color(i.image.rectTransform, targetColor,0.5f).setOnUpdate((Color color) => { i.image.color = color; }); 

    //     // LeanTween.value( i, updateValueExampleCallback,i.image.color, targetColor  1f);
     
    // }

    
    void Set_button()
    {
        LeanTween.alphaCanvas(i.GetComponent<CanvasGroup>(), 1f, 0.5f).setDelay(1.5f);
        Invoke("boutonon", 2f);
        
        // LeanTween.alpha( i , 1f, 0.5f);

    }

    void boutonon()
    {
        i.GetComponent<CanvasGroup>().blocksRaycasts = true;
        i.interactable = true;
    }

    void Game_win_but()
    {
        i.GetComponent<CanvasGroup>().blocksRaycasts = false;
        i.interactable = false;
        LeanTween.color(i.image.rectTransform, wincolor,1.3f).setOnUpdate((Color color) => { i.image.color = color; }).setDelay(0.5f); 
        LeanTween.alphaCanvas(i.GetComponent<CanvasGroup>(), 0f, 0.5f).setDelay(UnityEngine.Random.Range(1f, 2f) );
        LeanTween.color(i.image.rectTransform, normalcolor,1.3f).setOnUpdate((Color color) => { i.image.color = color; }).setDelay(4f); 
        // Invoke("InfoGamesuivante", 3.5f);
        

    }


    // void InfoGamesuivante()
    // {
    //     GameManager.Instance.StartGame();

    // }

    void Game_lost_but()
    {
        i.interactable = false;
        LeanTween.color(i.image.rectTransform, lostcolor,1.3f).setOnUpdate((Color color) => { i.image.color = color; }).setDelay(1f); 
        i.transform.DOShakePosition(3f, 10f).SetDelay(1f);
        LeanTween.alphaCanvas(i.GetComponent<CanvasGroup>(), 0f, 0.5f).setDelay(4f) ;
        LeanTween.color(i.image.rectTransform, normalcolor,1.3f).setOnUpdate((Color color) => { i.image.color = color; }).setDelay(6f); 
        
        

        // Invoke("ChangeBodyType",UnityEngine.Random.Range(1f,4f));
        
       
    }

   

    void ChangeBodyType()
    {
        rb = i.GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
    }


    
}
