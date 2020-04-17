using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overture_Porte : MonoBehaviour
{
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
        if(canOpen == true)
        {
            if (Input.GetButtonDown("Interact"))
            {
                if(opened == false)
                {
                    animator.SetBool("Open", true);
                    animator.SetBool("Close", false);
                    opened = true;
                }
                if(opened == true)
                {
                    animator.SetBool("Open", false);
                    animator.SetBool("Close", true);
                    opened = false;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            canOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            canOpen = false;
        }
    }
}
