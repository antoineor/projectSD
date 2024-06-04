using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class returnfromlevelchoix : MonoBehaviour
{
    public Button i;
    public EasymodeScript ES;
    public GameObject mere;
   
    void Start()
    {
        
    }

    public void startreturn ()
    {
        if (ES.isonEM==1)
        {
            i.interactable = true ;

        }
        // i.GetComponent<CanvasGroup>().blocksRaycasts = true;
         
    }


    // Update is called once per frame
    public void set_off_all()
    {
        i.transform.DOPunchScale(Vector3.one * 0.15f, 0.2f);
        mere.GetComponent<CanvasGroup>().blocksRaycasts = false;
        mere.GetComponent<CanvasGroup>().alpha = 0f;
        
    }
}
