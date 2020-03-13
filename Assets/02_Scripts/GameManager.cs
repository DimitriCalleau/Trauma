using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int nbLvlDone;
    public bool end = false;
    static int saveLvlDone;

    public GameObject fog1;
    public GameObject fog2;
    public GameObject fog3;
    public GameObject fog4;
    public GameObject fog5;


    bool fog1Activated;
    bool fog2Activated;
    bool fog3Activated;
    bool fog4Activated;
    bool fog5Activated;

    private void Start()
    {
        nbLvlDone = saveLvlDone;

        fog1Activated = true;
        fog2Activated = true;
        fog3Activated = true;
        fog4Activated = true;
        fog5Activated = true;
    }
    private void Update()
    {
        if (saveLvlDone < nbLvlDone)
        {
            saveLvlDone = nbLvlDone;
        }

        if(nbLvlDone >= 6)
        {
            end = true;
        }

        if(nbLvlDone >= 1)//fog1
        {
            if (fog1 != null)
            {
                Debug.Log("hidefog1");
                if(fog1Activated == true)
                {
                    fog1.SetActive(false);
                    fog1Activated = false;
                }
            }
        }
        if(nbLvlDone >= 2) //fog2
        {
            if (fog2 != null)
            {
                if(fog2Activated == true)
                {
                    fog2.SetActive(false);
                    fog2Activated = false;
                }
            }
        }
        if(nbLvlDone >= 3)//fog3
        {
            if (fog3 != null)
            {
                if(fog3Activated == true)
                {
                    fog3.SetActive(false);
                    fog3Activated = false;
                }
            }
        }
        if(nbLvlDone >= 4)//fog4
        {
            if (fog4 != null)
            {
                if(fog4Activated == true)
                {
                    fog4.SetActive(false);
                    fog4Activated = false;
                }
            }
        }
        if(nbLvlDone >= 5)//fog5
        {
            if (fog5 != null)
            {
                if(fog5Activated == true)
                {
                    fog5.SetActive(false);
                    fog5Activated = false;
                }
            }
        }

    }
}
