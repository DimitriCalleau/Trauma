using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPeur : MonoBehaviour
{
    Rigidbody2D rb;
    public float mvtSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb.velocity = new Vector2(mvtSpeed, rb.velocity.y);
    }
}
