using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFleche : MonoBehaviour
{
    public GameObject player;

    public GameObject fleche;
    public GameObject flecheFinColere;

    public float timeBetweenArrows;
    public float timeBetweenEndArrows;
    float timer;
    bool playerPause;


    private void Start()
    {
        timer = timeBetweenArrows;
    }
    void Update()
    {
        if (playerPause = player.GetComponent<Controller2D>().finColere == false)
        {
            
            if (player.GetComponent<Controller2D>().pause == false)
            {
                if (fleche != null)
                {
                    if (timer <= 0)
                    {
                        Instantiate(fleche, transform.position, Quaternion.identity);
                        if (timeBetweenArrows > 1)
                        {
                            timeBetweenArrows -= 0.1f;
                        }
                        timer = timeBetweenArrows;
                    }
                    timer -= Time.deltaTime;
                }
            }
        }
        else
        {
            if (player.GetComponent<Controller2D>().pause == false)
            {
                if (timer <= 0)
                {
                    Instantiate(flecheFinColere, transform.position, Quaternion.identity);
                    timer = timeBetweenEndArrows;
                }
                timer -= Time.deltaTime;
            }

        }

    }
}
