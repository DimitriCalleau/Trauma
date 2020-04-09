using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialObject : MonoBehaviour
{
    public GameManager menu3D;
    public GameObject player;

    public int nbObjet;
    public string sceneToLoad;
    public Renderer rnd;
    public Material[] mats = new Material[2];
    private int activeMat;
    public bool lvlDone;

    private void Start()
    {
        rnd.material = mats[0];
        activeMat = 0;
    }

    private void Update()
    {
        if (menu3D != null)
        {
            if (menu3D.GetComponent<GameManager>().nbLvlDone >= nbObjet)
            {
                if (lvlDone == false)
                {
                    lvlDone = true;
                }
            }
        }

        if(lvlDone == true)
        {
            this.gameObject.layer = 9;
            if(activeMat == 0)
            {
                rnd.material = mats[1];
                activeMat = 1;
            }
        }
    }
}
