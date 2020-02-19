using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFleche : MonoBehaviour
{
    public GameObject fleche;
    public float timeBetweenArrows;
    float timer;

    void Update()
    {
        if(fleche != null)
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
