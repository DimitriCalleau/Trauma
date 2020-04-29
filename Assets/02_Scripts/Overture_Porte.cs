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
    bool canOpen;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        open = false;
        opened = false;
        canOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        NblvlDone = player.GetComponent<PlayerController>().nbLvlDonePorte;

        if(NblvlDone >= lvlToUnlock)
        {
            if (canOpen == true)
            {
                if (Input.GetButtonDown("Interact"))
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            canOpen = true;
            //Debug.Log("can open");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            canOpen = false;
            //Debug.Log("can not open");
        }
    }
}
