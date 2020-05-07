using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int nbLvlDone;
    static int saveLvlDone;

    private void Start()
    {
        //nbLvlDone = saveLvlDone;
        nbLvlDone = 2;
    }
    private void Update()
    {
        if (saveLvlDone < nbLvlDone)
        {
            saveLvlDone = nbLvlDone;
        }
    }

    public void lvlDoneForce()
    {
        saveLvlDone = nbLvlDone;
    }
}
