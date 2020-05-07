using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int nbLvlDone;
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
    }

    public void lvlDoneForce()
    {
        saveLvlDone = nbLvlDone;
    }
}
