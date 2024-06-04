using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RestartGame : MonoBehaviour
{
    public Button rest;
    
    
    // Start is called before the first frame update
    void Start()
    {
        GrilleButtonScript.game_lost += restart_butt;
        GrilleButtonScript.levelnondebloque += restart_butt;
    }

    // Update is called once per frame
    void OnDestroy()
    {
       
        GrilleButtonScript.game_lost -= restart_butt;
        GrilleButtonScript.levelnondebloque -= restart_butt;
    }

    void restart_butt()
    {
        Invoke("boutonon", 4f);
        LeanTween.alphaCanvas(rest.GetComponent<CanvasGroup>(), 1f, 1f).setDelay(4f);;

    }

         
        
      
    
    void boutonon()
    {
        rest.interactable = true;
        rest.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void no_butt()
    {
        rest.transform.DOPunchScale(Vector3.one * 0.15f, 0.2f);
        rest.interactable = false;
        rest.GetComponent<CanvasGroup>().blocksRaycasts = false;
        LeanTween.alphaCanvas(rest.GetComponent<CanvasGroup>(), 0f, 1f);

    }
}
