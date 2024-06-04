using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class phasechoix : MonoBehaviour
{
    public int phase = 1;
    public Button i;
    public Text j;
    public GameObject p1;
    public GameObject p2;
    public GameObject mere;
    public EasymodeScript ES;

    void Start()
    {
        
    }

    public void startphase ()
    {
        if (ES.isonEM==1)
        {
            i.interactable = true ;
            mere.GetComponent<CanvasGroup>().blocksRaycasts = true;
            mere.GetComponent<CanvasGroup>().alpha = 1f;

        }
        // i.GetComponent<CanvasGroup>().blocksRaycasts = true;
        
            
    }

    // Update is called once per frame
    public void changephase ()
    {
        i.transform.DOPunchScale(Vector3.one * 0.15f, 0.2f);
        j.transform.DOPunchScale(Vector3.one * 0.15f, 0.2f);
        
        if (phase == 1)
        {
            j.text = "Phase 2";
            p1.GetComponent<CanvasGroup>().blocksRaycasts = false;
            p1.GetComponent<CanvasGroup>().alpha = 0f;
            p2.GetComponent<CanvasGroup>().blocksRaycasts = true;
            p2.GetComponent<CanvasGroup>().alpha = 1f;
            phase = 2;
        }
        else 
        {
            j.text = "Phase 1";
            p1.GetComponent<CanvasGroup>().blocksRaycasts = true;
            p1.GetComponent<CanvasGroup>().alpha = 1f;
            p2.GetComponent<CanvasGroup>().blocksRaycasts = false;
            p2.GetComponent<CanvasGroup>().alpha = 0f;
            phase = 1;
        }
            
    }
}
