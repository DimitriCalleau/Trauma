using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlecheColere : MonoBehaviour
{
    
    public float damages; // pas superieur a 1
    public int speed;
    public float lifetime;
    float timer;
    private void Start()
    {
        timer = lifetime;
    }
    private void Update()
    {
        Rigidbody2D billy;
        billy = this.GetComponent<Rigidbody2D>();
        Debug.Log(billy);
        if(billy != null)
        {
            billy.AddForce(Vector2.left * speed * Time.deltaTime);
        }
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            collision.gameObject.GetComponent<Controller2D>().stackColere += damages;
            Destroy(this.gameObject);
        }
    }
}
