using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlecheColere : MonoBehaviour
{
    public Sprite[] mot;
    public SpriteRenderer sprRenderer;

    public ParticleSystem trail;
    public ParticleSystem explosionParticle;

    public float damages; // pas superieur a 1
    public int speed;
    public float lifetime;
    float timer;

    private void Awake()
    {
        //trail.Play();
        int random = Random.Range(0, (mot.Length));
        sprRenderer.sprite = mot[random];

    }
    private void Start()
    {
        timer = lifetime;
    }
    private void Update()
    {
        Rigidbody2D billy;
        billy = this.GetComponent<Rigidbody2D>();
        if(billy != null)
        {
            billy.AddForce(Vector2.left * speed * Time.deltaTime);
        }
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            //StartCoroutine(ArrowExplosion());

            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            //StartCoroutine(ArrowExplosion());
            Destroy(this.gameObject);
            collision.gameObject.GetComponent<Controller2D>().stackColere += damages;
            collision.gameObject.GetComponent<Controller2D>().ActivateFlammes();
            Destroy(this.gameObject);
        }
    }

    public IEnumerator ArrowExplosion()
    {
        explosionParticle.Play();
        yield return new WaitForSeconds(explosionParticle.main.duration);
        Destroy(this);
    }
}
