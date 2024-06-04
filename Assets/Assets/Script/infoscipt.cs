using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class infoscipt : MonoBehaviour
{
    public Text text;
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
       
        GrilleButtonScript.levelnondebloque += fadingtext;
        
    }

    void OnDestroy()
    {
     
        GrilleButtonScript.levelnondebloque -= fadingtext;

    }

    public void fadingtext() 
    {
        if (player.levelmain == 30)
        {
            text.text = "Well done, More to come...";
        }
        LeanTween.alphaCanvas(text.GetComponent<CanvasGroup>(), 1f, 0.5f).setDelay(2f);

    }
    public void fadingtextr() 
    {
        LeanTween.alphaCanvas(text.GetComponent<CanvasGroup>(), 0f, 0.5f);
    }
}
