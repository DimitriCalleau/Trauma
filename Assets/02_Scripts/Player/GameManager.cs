using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int nbLvlDone;
    static int saveLvlDone;

    public GameObject joie;
    public GameObject incompehension;
    public GameObject peur;
    public GameObject culpabilite;
    public GameObject colere;
    public GameObject tristesse;
    int lvldone;

    private void Start()
    {
        //nbLvlDone = saveLvlDone;
        nbLvlDone = 1;
    }
    private void Update()
    {
        if (saveLvlDone < nbLvlDone)
        {
            saveLvlDone = nbLvlDone;
        }

        if(saveLvlDone == 1)
        {
            joie.GetComponent<SpecialObject>().ChangeMat();
        }
        if(saveLvlDone == 2)
        {
            incompehension.GetComponent<SpecialObject>().ChangeMat();
        }
        if(saveLvlDone == 3)
        {
            peur.GetComponent<SpecialObject>().ChangeMat();
        }
        if(saveLvlDone == 4)
        {
            culpabilite.GetComponent<SpecialObject>().ChangeMat();
        }
        if(saveLvlDone == 5)
        {
            colere.GetComponent<SpecialObject>().ChangeMat();
        }
        if(saveLvlDone == 6)
        {
            tristesse.GetComponent<SpecialObject>().ChangeMat();
            saveLvlDone = 7;
        }


    }

    public void lvlDoneForce()
    {
        saveLvlDone = nbLvlDone;
    }
}
