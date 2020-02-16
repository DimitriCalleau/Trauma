using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2D : MonoBehaviour
{
    //General
    public GameObject menu2D;
    public bool pause;
    public int lvlActif;
    public bool isDead;

    //Movement
    Rigidbody2D rb;
    public float mvtSpeed;
    //Jump
    public float jumpForce;
    public int maxJump;
    int nbJump;
    bool isGrounded;

    //Lvl Bougie
    private int checkPoint;
    public int nbCheckpoint;

    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead == true)
        {
            menu2D.GetComponent<SceneAndUI>().Retry();
        }
        pause = menu2D.GetComponent<SceneAndUI>().pause;
        if (pause == false)
        {
            //MVT
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            bool jump = Input.GetButtonDown("Jump");

            if (h > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            if (h < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            if (h != 0)
            {
                rb.velocity = new Vector2(mvtSpeed * h, rb.velocity.y);
            }
            if (h == 0)
            {
                if(isGrounded == true)
                {
                    rb.velocity = new Vector2(0f, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
                }
            }
            if (rb.velocity.x >= mvtSpeed)
            {
                rb.velocity = new Vector2(mvtSpeed, rb.velocity.y);
            }
            if (rb.velocity.x <= -mvtSpeed)
            {
                rb.velocity = new Vector2(-mvtSpeed, rb.velocity.y);
            }

            // le saut
            if (nbJump < maxJump && jump == true)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.deltaTime);
                nbJump += 1;
                isGrounded = false;
            }

            if(checkPoint >= nbCheckpoint)
            {

                menu2D.GetComponent<GameManager>().nbLvlDone += 1;
                menu2D.GetComponent<SceneAndUI>().SceneLoader("Maison");
            }
        }
    }   
    //Détecte les collisions(pour le jump et mort)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            isGrounded = true;
            nbJump = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            menu2D.GetComponent<SceneAndUI>().Retry();
        }
        if (collision.gameObject.tag.Equals("Finish"))
        {
            menu2D.GetComponent<GameManager>().nbLvlDone += 1;
            menu2D.GetComponent<SceneAndUI>().SceneLoader("Maison");
        }
        if (collision.gameObject.tag.Equals("checkPoint"))
        {
            checkPoint += 1;
        }
    }
}
