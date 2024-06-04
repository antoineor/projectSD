using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EasymodeScript : MonoBehaviour
{
    public int isonEM;
    public Button EM; 
    public Color Onc;
    public Color Offc;
    public Text modejeu;

    // Start is called before the first frame update
    void Start()
    {
        
        
        if (PlayerPrefs.HasKey("isonEM"))
            isonEM = PlayerPrefs.GetInt("isonEM");
        else
            isonEM = 0;
        
        if (isonEM == 0)
        {
            
            EM.transform.DOPunchScale(Vector3.one * 0.15f, 0.2f);
            
            modejeu.text = "Normal Mode";
            LeanTween.color(EM.image.rectTransform, Offc,0.2f).setOnUpdate((Color color) => { EM.image.color = color; }); 


        }

        if (isonEM == 1)
        {
            EM.transform.DOPunchScale(Vector3.one * 0.15f, 0.2f);
            modejeu.text = "Train Mode";
            LeanTween.color(EM.image.rectTransform, Onc,0.2f).setOnUpdate((Color color) => { EM.image.color = color; }); 
        }
        
    }

    // Update is called once per frame
    public void EMbutton_pressed()
    {
        isonEM = 1 - isonEM;
        PlayerPrefs.SetInt("isonEM", isonEM);

        if (isonEM == 0)
        {
            EM.transform.DOPunchScale(Vector3.one * 0.15f, 0.2f);
            modejeu.text = "Normal Mode";
            
            LeanTween.color(EM.image.rectTransform, Offc,0.2f).setOnUpdate((Color color) => { EM.image.color = color; }); 


        }

        if (isonEM == 1)
        {
            EM.transform.DOPunchScale(Vector3.one * 0.15f, 0.2f);
            modejeu.text = "Train Mode";
            LeanTween.color(EM.image.rectTransform, Onc,0.2f).setOnUpdate((Color color) => { EM.image.color = color; }); 
        }
        
    }
}
