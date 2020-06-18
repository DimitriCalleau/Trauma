using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPeur : MonoBehaviour
{
    Rigidbody2D rb;
    float mvtSpeed;
    public float speed;
    public GameObject player;

    void Start()
    {
        mvtSpeed = speed;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (player.GetComponent<Controller2D>().respawnPeur == true)
        {
            transform.position = new Vector2(player.transform.position.x - 8, transform.position.y);
            player.GetComponent<Controller2D>().respawnPeur = false;
        }
        rb.velocity = new Vector2(mvtSpeed, rb.velocity.y);

        if (player.GetComponent<Controller2D>().pause == false)
        {
            if (mvtSpeed != speed)
            {
                mvtSpeed = speed;
            }
        }
        else
        {
            if (mvtSpeed != 0)
            {
                mvtSpeed = 0;
            }
        }
    }
}
