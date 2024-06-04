using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class levelchoix : MonoBehaviour
{
    public Button i;
    public int level ;
    public int phase ;
    public GameObject mere;
    public int highScore;

    
    void Start()
    {
       GameManager.choixniveau += gointeract;
     
    }

    void OnDestroy()
    {
        GameManager.choixniveau -= gointeract;
     
    }

    public void gointeract()
    {
        Invoke("gobut", 0.2f);
        
    }

    public void gobut()
    {
        if (PlayerPrefs.HasKey("HighScore"))
            highScore = PlayerPrefs.GetInt("HighScore");
        else
            highScore = 0;

        if (highScore>=level || level == 1)
        {
            i.interactable = true ;
        }
        
    }

    public void startlevel()
    {
        i.interactable = false;
        mere.GetComponent<CanvasGroup>().blocksRaycasts = false;
        mere.GetComponent<CanvasGroup>().alpha = 0f;
        
        GameManager.Instance.startonlevel(  phase, level);

    }


}
