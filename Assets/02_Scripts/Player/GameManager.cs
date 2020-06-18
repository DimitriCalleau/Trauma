using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public int nbLvlDone;
    static int saveLvlDone;

    public GameObject joie;
    public GameObject joieHaut;
    public GameObject joieInterieur;
    public GameObject incompehension;
    public GameObject peur;
    public GameObject culpabilite;
    public GameObject colere;
    public GameObject tristesse;

    bool changed1;
    bool changed2;
    bool changed3;
    bool changed4;
    bool changed5;
    bool changed6;
    bool old1;
    bool old2;
    bool old3;
    bool old4;
    bool old5;
    bool old6;


    public GameObject[] decalsPorte;

    public GameObject text;

    int lvldone;

    private void Start()
    {
        nbLvlDone = PlayerPrefs.GetInt("nbLvlDone");
        //nbLvlDone = 5;
    }
    private void Update()
    {
        if (saveLvlDone < nbLvlDone)
        {
            saveLvlDone = nbLvlDone;
        }

        if(nbLvlDone >= 1)
        {
            if(changed1 == false)
            {
                if (joie != null)
                {
                    joie.GetComponent<SpecialObject>().ChangeMat();
                    joieHaut.GetComponent<SpecialObject>().ChangeMat();
                    joieInterieur.GetComponent<SpecialObject>().ChangeMat();
                    decalsPorte[0].SetActive(true);
                    changed1 = true;
                    old1 = false;
                }
            }

        }
        else if(nbLvlDone < 1)
        {
            if (old1 == false)
            {
                if (joie != null)
                {
                    joie.GetComponent<SpecialObject>().OldMat();
                    joieHaut.GetComponent<SpecialObject>().OldMat();
                    joieInterieur.GetComponent<SpecialObject>().OldMat();
                    decalsPorte[0].SetActive(false);
                    changed1 = false;
                    old1 = true;
                }
            }
        }

        if (nbLvlDone >= 2)
        {
            if (changed2 == false)
            {
                if (incompehension != null)
                {
                    incompehension.GetComponent<SpecialObject>().ChangeMat();
                    decalsPorte[1].SetActive(true);
                    changed2 = true;
                    old2 = false;
                }
            }
        }
        else if (nbLvlDone < 2)
        {
            if (old2 == false)
            {
                if (incompehension != null)
                {
                    incompehension.GetComponent<SpecialObject>().OldMat();
                    decalsPorte[1].SetActive(false);
                    old2 = true;
                    changed2 = false;
                }
            }

        }

    
        if (nbLvlDone >= 3)
        {
            if(changed3 == false)
            {
                if (peur != null)
                {
                    peur.GetComponent<SpecialObject>().ChangeMat();
                    decalsPorte[2].SetActive(true);
                    changed3 = true;
                    old3 = false;
                }
            }
        }    
        else if (nbLvlDone < 3)
        {
            if (old3 == false)
            {
                if (peur != null)
                {
                    peur.GetComponent<SpecialObject>().OldMat();
                    decalsPorte[2].SetActive(false);
                    old3 = true;
                    changed3 = false;
                }
            }
        }

        if (nbLvlDone >= 4)
        {
            if(changed4 == false)
            {
                if (culpabilite != null)
                {
                    culpabilite.GetComponent<SpecialObject>().ChangeMat();
                    decalsPorte[3].SetActive(true);
                    changed4 = true;
                    old4 = false;
                }
            }
        }
        else if (nbLvlDone < 4)
        {
            if (old4 == false)
            {
                if (culpabilite != null)
                {
                    culpabilite.GetComponent<SpecialObject>().OldMat();
                    decalsPorte[3].SetActive(false);
                    old4 = true;
                    changed4 = false;
                }
            }
        }

        if (nbLvlDone >= 5)
        {
            if(changed5 == false)
            {
                if (colere != null)
                {
                    colere.GetComponent<SpecialObject>().ChangeMat();
                    decalsPorte[4].SetActive(true);
                    changed5 = true;
                    old5 = false;
                }
            }
        }
        else if (nbLvlDone < 5)
        {
            if (old5 == false)
            {
                if (colere != null)
                {
                    colere.GetComponent<SpecialObject>().OldMat();
                    decalsPorte[4].SetActive(false);
                    old5 = true;
                    changed5 = false;
                }
            }
        }

        if (nbLvlDone >= 6)
        {
            if(changed6 == false)
            {
                if (tristesse != null)
                {
                    tristesse.GetComponent<SpecialObject>().ChangeMat();
                    decalsPorte[5].SetActive(true);
                    saveLvlDone = 7;
                    changed6 = true;
                    old6 = true;
                }
            }
        }
        else if (nbLvlDone < 6)
        {
            if (old6 == false)
            {
                if (tristesse != null)
                {
                    tristesse.GetComponent<SpecialObject>().OldMat();
                    decalsPorte[5].SetActive(false);
                    old6 = true;
                    changed6 = true;
                }
            }
        }

    }

    public void lvlDoneForce()
    {
        saveLvlDone = nbLvlDone;
    }
}
