using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CharacterJump : MonoBehaviour


{
    public int i;
    public Button j;
    public int y;
    public Text text;

    public void StartJumping() 
    {
        j.transform.DOPunchScale(Vector3.one * 0.15f, 0.2f);
        j.interactable = false;
        j.GetComponent<CanvasGroup>().blocksRaycasts = false;
        LeanTween.alphaCanvas(j.GetComponent<CanvasGroup>(), 0f, 0.5f);
    }

    public void fading() 
    {
        j.interactable = false;
        j.GetComponent<CanvasGroup>().blocksRaycasts = false;
        LeanTween.alphaCanvas(j.GetComponent<CanvasGroup>(), 0f, 0.5f);
    }
    public void fadingtext() 
    {
        LeanTween.alphaCanvas(text.GetComponent<CanvasGroup>(), 0f, 0.5f);
    }

    public void ReturnJumping() 
    {
        // transform.LeanMoveX(400, 3f).setEaseInQuart();
        LeanTween.alphaCanvas(j.GetComponent<CanvasGroup>(), 1f, 1f);
        
        j.GetComponent<CanvasGroup>().blocksRaycasts = true;
        Invoke("boutonon", 3f);
    }

    void boutonon ()
    {
        j.interactable = true;
    }
    public void returnfading() 
    {
        j.interactable = true;
        j.GetComponent<CanvasGroup>().blocksRaycasts = true;
        LeanTween.alphaCanvas(j.GetComponent<CanvasGroup>(), 1f, 1f);
    }
    public void returnfadingtext() 
    {
        LeanTween.alphaCanvas(text.GetComponent<CanvasGroup>(), 1f, 1f);
    }
    
    
  
}