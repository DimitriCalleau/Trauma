using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialObject : MonoBehaviour
{
    public ParticleSystem prtc;
    public int nbObjet;
    public string sceneToLoad;
    public GameObject futurePanel;
    public Renderer rnd;
    public Material[] mats = new Material[2];
    private int activeMat;

    private void Start()
    {
        rnd.material = mats[0];
        activeMat = 0;
        if(prtc != null)
        {
            prtc.Play();
        }
    }

    public void ChangeMat()
    {
        this.gameObject.layer = 9;
        if (activeMat == 0)
        {
            if (prtc != null)
            {
                prtc.Stop();
            }
            rnd.material = mats[1];
            activeMat = 1;
        }
    }

    public void OldMat()
    {
        this.gameObject.layer = 11;
        if (activeMat == 1)
        {
            rnd.material = mats[0];
            activeMat = 0;
            prtc.Play();
        }
    }
}
