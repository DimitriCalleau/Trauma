using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int nbLvlDone;
    public bool end = false;
    static int saveLvlDone;

    private void Start()
    {
        nbLvlDone = saveLvlDone;
        //nbLvlDone = 4;  truc de test
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
    }
}
