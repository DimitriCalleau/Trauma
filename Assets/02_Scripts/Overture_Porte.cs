using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overture_Porte : MonoBehaviour
{
    public int lvlToUnlock;
    int NblvlDone;
    public GameObject player;

    bool open;
    bool opened;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        open = false;
        opened = false;
    }

    // Update is called once per frame
    void Update()
    {
        NblvlDone = player.GetComponent<PlayerController>().nbLvlDonePorte;

    }

    public void Open()
    {
        if (NblvlDone >= lvlToUnlock)
        {
            if (opened == false)
            {
                animator.SetBool("Open", true);
                opened = true;
            }
            else
            {
                animator.SetBool("Open", false);
                opened = false;
            }
        }
    }
}
