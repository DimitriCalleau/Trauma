using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFleche : MonoBehaviour
{
    public GameObject player;

    public GameObject fleche;

    public float timeBetweenArrows;
    float timer;
    bool playerPause;

    void Update()
    {
        playerPause = player.GetComponent<Controller2D>().pause;
        if(playerPause == false)
        {
            if (fleche != null)
            {
                if (timer <= 0)
                {
                    Instantiate(fleche, transform.position, Quaternion.identity);
                    timer = timeBetweenArrows;
                }
                timer -= Time.deltaTime;
            }
        }
    }
}
