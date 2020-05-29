using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Mat : MonoBehaviour
{
    public Material[] mats;
    public MeshRenderer meshRdr;
    bool mat;
    bool activate;
    // Start is called before the first frame update
    void Start()
    {
        meshRdr.material = mats[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(activate == true)
        {
            if (Input.GetButton("Interact"))
            {
                if (mat == false)
                {
                    meshRdr.material = mats[0];
                    mat = true;
                    Debug.Log("penis");

                }
                if (mat == true)
                {
                    meshRdr.material = mats[1];
                    mat = false;
                    Debug.Log("penis");

                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            activate = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        activate = false;
    }
}
