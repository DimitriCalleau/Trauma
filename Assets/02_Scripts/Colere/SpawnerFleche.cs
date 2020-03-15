﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFleche : MonoBehaviour
{
    public GameObject flecheA;
    public GameObject flecheB;
    public float timeBetweenArrows;
    float timer;
    bool playerPause;

    void Update()
    {
        playerPause = transform.GetComponentInParent<Controller2D>().pause;
        if(playerPause == false)
        {
            if (flecheA != null)
            {
                if (timer <= 0)
                {
                    Instantiate(flecheA, transform.position, Quaternion.identity);
                    timer = timeBetweenArrows;
                }
                timer -= Time.deltaTime;
            }
        }
    }
}
