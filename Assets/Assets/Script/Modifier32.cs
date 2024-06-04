using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modifier32 : MonoBehaviour
{
    public int positionx ;
    public int positiony ;
    public GameObject carre;
    public Color color_win;
    public Color color_lost;
    public Color ncolor;
    public Color p2color;
    public Color vcolor;
    

    void Start()
    {
       
        PlayerController.fin_creation_matrice += modify_color;
        GrilleButtonScript.game_win += Game_win_but;
        GrilleButtonScript.game_lost += Game_lost_but;
        GrilleButtonScript.levelnondebloque += Game_win_but;
    }

     void OnDestroy()
    {
        PlayerController.fin_creation_matrice -= modify_color;
        GrilleButtonScript.game_win -= Game_win_but;
        GrilleButtonScript.game_lost -= Game_lost_but;
        GrilleButtonScript.levelnondebloque -= Game_win_but;
    }

    public void modify_color()

    {
        if ( PlayerController.matrice_grid[ positionx , positiony ] == 0 )
        {
            LeanTween.color(carre, ncolor, 1f).setDelay(0.8f).setEaseInQuart();
        }

        if ( PlayerController.matrice_grid[ positionx , positiony ] == 1 )
        {
            LeanTween.color(carre, Color.black, 1f).setDelay(0.8f).setEaseInQuart();
        }
        if ( PlayerController.matrice_grid[ positionx , positiony ] == 2 )
        {
            LeanTween.color(carre, p2color, 1f).setDelay(0.8f).setEaseInQuart();
        }

    }

    void Game_lost_but()
    {
        LeanTween.color(carre, color_lost, 1.3f).setDelay(1f).setEaseInQuart();
        // LeanTween.color(carre, ncolor, 1.3f).setDelay(5f).setEaseInQuart();
    }

    void Game_win_but()
    {
        LeanTween.color(carre, color_win, 1.3f).setDelay(0.5f).setEaseInQuart();
        LeanTween.alpha( carre , 0f, 0.5f).setDelay(UnityEngine.Random.Range(1.5f, 2f));
        // LeanTween.color(carre, vcolor, 0.5f).setDelay(UnityEngine.Random.Range(1f, 2f)).setEaseInQuart();
        LeanTween.color(carre, ncolor, 0.2f).setDelay(3.5f).setEaseInQuart();
    }
}
