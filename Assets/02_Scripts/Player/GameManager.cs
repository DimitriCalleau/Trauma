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

    public GameObject[] decalsPorte;

    int lvldone;

    private void Start()
    {
        //nbLvlDone = saveLvlDone;
        nbLvlDone = 6;
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
            decalsPorte[0].SetActive(true);
        }
        if (saveLvlDone == 2)
        {
            incompehension.GetComponent<SpecialObject>().ChangeMat();
            decalsPorte[1].SetActive(true);
        }
        if (saveLvlDone == 3)
        {
            peur.GetComponent<SpecialObject>().ChangeMat();
            decalsPorte[2].SetActive(true);
        }
        if (saveLvlDone == 4)
        {
            culpabilite.GetComponent<SpecialObject>().ChangeMat();
            decalsPorte[3].SetActive(true);
        }
        if (saveLvlDone == 5)
        {
            colere.GetComponent<SpecialObject>().ChangeMat();
            decalsPorte[4].SetActive(true);
        }
        if (saveLvlDone == 6)
        {
            tristesse.GetComponent<SpecialObject>().ChangeMat();
            decalsPorte[5].SetActive(true);
            saveLvlDone = 7;
        }


    }

    public void lvlDoneForce()
    {
        saveLvlDone = nbLvlDone;
    }
}
