using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialObject : MonoBehaviour
{
    public int nbObjet;
    public string sceneToLoad;
    public Renderer rnd;
    public Material[] mats = new Material[2];
    private int activeMat;

    private void Start()
    {
        rnd.material = mats[0];
        activeMat = 0;
    }

    public void ChangeMat()
    {
        this.gameObject.layer = 9;
        if (activeMat == 0)
        {
            rnd.material = mats[1];
            activeMat = 1;
        }
    }
}
