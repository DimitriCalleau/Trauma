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
    float angle;
    bool canTurn;

    // Start is called before the first frame update
    void Start()
    {
      
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

        if(canTurn == true)
        {
            angle += 1000 * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }

        if (anmTimer <= 0)
        {
            if (phase == 0)
            {
                canTurn = true;
                //anm.SetBool("Move", true);
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
                canTurn = false;
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                angle = 0;
                //anm.SetBool("Move", false);
                bxCo.isTrigger = false;
                transform.gameObject.layer = 8;
                anmTimer = anmTiming;
                phase = 0;
            }
        }
    }
}
