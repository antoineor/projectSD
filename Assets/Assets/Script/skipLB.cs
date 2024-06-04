
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class skipLB : MonoBehaviour
{
    public Button skip;
    

    // Start is called before the first frame update
     void Start()
    {
        PlayerController.fin_creation_matrice += restart_butt;
        TriggerGame.Debut_game += no_butt;

    }

    void OnDestroy()
    {
        PlayerController.fin_creation_matrice -= restart_butt;
        TriggerGame.Debut_game -= no_butt;
    }

    void restart_butt()
    {
        if (GameManager.Instance.mode == 1)
        {
            skip.interactable = true;
            skip.GetComponent<CanvasGroup>().blocksRaycasts = true;
            LeanTween.alphaCanvas(skip.GetComponent<CanvasGroup>(), 1f, 1f).setDelay(3f);
        }

    }

    public void no_butt()
    {
        skip.transform.DOPunchScale(Vector3.one * 0.15f, 0.2f);
        skip.interactable = false;
        skip.GetComponent<CanvasGroup>().blocksRaycasts = false;
        LeanTween.alphaCanvas(skip.GetComponent<CanvasGroup>(), 0f, 0.1f);

    }
}
