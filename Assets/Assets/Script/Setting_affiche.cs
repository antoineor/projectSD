using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Setting_affiche : MonoBehaviour
{
    public GameObject i;
    public Button j;
    public Button k;
    public Button l;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    void OnDestroy()
    {
       
    }

    public void Setting_affiche_f()
    {
        i.GetComponent<CanvasGroup>().blocksRaycasts = true;
        j.interactable = true;
        j.GetComponent<CanvasGroup>().blocksRaycasts = true;
        k.interactable = true;
        k.GetComponent<CanvasGroup>().blocksRaycasts = true;
        l.interactable = true;
        l.GetComponent<CanvasGroup>().blocksRaycasts = true;
        // LeanTween.alphaCanvas(j.GetComponent<CanvasGroup>(), 1f, 0.5f) ;
        LeanTween.alphaCanvas(i.GetComponent<CanvasGroup>(), 1f, 0.5f) ;
    }

    public void Setting_cache()
    {
        i.GetComponent<CanvasGroup>().blocksRaycasts = false;
        j.interactable = false;
        j.GetComponent<CanvasGroup>().blocksRaycasts = false;
        k.interactable = false;
        k.GetComponent<CanvasGroup>().blocksRaycasts = false;
        l.interactable = false;
        l.GetComponent<CanvasGroup>().blocksRaycasts = false;
        LeanTween.alphaCanvas(i.GetComponent<CanvasGroup>(), 0f, 0.5f);
    }

    

}




