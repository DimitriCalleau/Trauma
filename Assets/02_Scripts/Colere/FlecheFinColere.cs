using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlecheFinColere : MonoBehaviour
{
    public Sprite[] mot;
    public SpriteRenderer sprRenderer;

    public ParticleSystem explosionParticle;

    public float damages; 
    public int speed;
    public float lifetime;
    float timer;

    private void Awake()
    {
       
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
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            StartCoroutine(ArrowExplosion());
            collision.gameObject.GetComponent<Controller2D>().FinColereExplosion();
        }
    }

    public IEnumerator ArrowExplosion()
    {
        transform.GetComponent<SpriteRenderer>().sprite = null;
        Instantiate(explosionParticle, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(explosionParticle.main.duration);
        Destroy(this);
    }
}
