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
    }
    private void Update()
    {
        if (saveLvlDone < nbLvlDone)
        {
            saveLvlDone = nbLvlDone;
        }
        
        Debug.Log("nombre de Lvl accomplient : " + nbLvlDone);

        if(nbLvlDone >= 6)
        {
            end = true;
        }
    }
}
