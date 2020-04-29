using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformMove : MonoBehaviour
{
    public Animator anm;
    public BoxCollider2D bxCo;
    public float anmTimer;
    public float anmTiming;
    public int phase;

    // Start is called before the first frame update
    void Start()
    {
        phase = 0;
        bxCo.isTrigger = false;
        anmTimer = anmTiming;
    }

    // Update is called once per frame
    void Update()
    {
        if(anmTimer >= 0)
        {
            anmTimer -= Time.deltaTime;
        }

        if (anmTimer <= 0)
        {
            if (phase == 0)
            {
                anm.SetBool("Move", true);
                bxCo.isTrigger = true;
                transform.gameObject.layer = 0;
                anmTimer = anmTiming;
                phase = 1;
            }
        }

        if (anmTimer <= 0)
        {
            if (phase == 1)
            {
                anm.SetBool("Move", false);
                bxCo.isTrigger = false;
                transform.gameObject.layer = 8;
                anmTimer = anmTiming;
                phase = 0;
            }
        }
    }
}
