using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourcentageNiveau : MonoBehaviour
{
    public Transform pointA;
    public Transform player;
    public float ratio;

    void Update()
    {
        ratio = 100 * ((player.position.x - pointA.position.x) / (transform.position.x - pointA.position.x));
    }
}
