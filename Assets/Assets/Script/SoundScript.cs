using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SoundScript : MonoBehaviour
{
    public int isonS;
    public Button S; 
    public Color Onc;
    public Color Offc;
    public GameObject son;
    public GameObject soff;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("isonS"))
            isonS = PlayerPrefs.GetInt("isonS");
        else
            isonS = 1;
        
        if (isonS == 0)
        {
            S.transform.DOPunchScale(Vector3.one * 0.15f, 0.2f);
            LeanTween.color(S.image.rectTransform, Offc,0.2f).setOnUpdate((Color color) => { S.image.color = color; }); 


        }

        if (isonS == 1)
        {
            S.transform.DOPunchScale(Vector3.one * 0.15f, 0.2f);
            LeanTween.color(S.image.rectTransform, Onc,0.2f).setOnUpdate((Color color) => { S.image.color = color; }); 
        }
    }

    // Update is called once per frame
    public void Sbutton_pressed()
    {
        isonS = 1 - isonS;
        PlayerPrefs.SetInt("isonS", isonS);
        
        if (isonS == 0)
        {

            S.transform.DOPunchScale(Vector3.one * 0.15f, 0.2f);
            soff.transform.DOPunchScale(Vector3.one * 0.15f, 0.2f);
            son.SetActive(false);
            soff.SetActive(true);
            LeanTween.color(S.image.rectTransform, Offc,0.2f).setOnUpdate((Color color) => { S.image.color = color; }); 


        }

        if (isonS == 1)
        {
            
            S.transform.DOPunchScale(Vector3.one * 0.15f, 0.2f);
            son.transform.DOPunchScale(Vector3.one * 0.15f, 0.2f);
            soff.SetActive(false);
            son.SetActive(true);
            LeanTween.color(S.image.rectTransform, Onc,0.2f).setOnUpdate((Color color) => { S.image.color = color; }); 
        }
        
    }
}
