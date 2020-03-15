using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller2D : MonoBehaviour
{
    //General
    public GameObject menu2D;
    public Image colereBar;
    public GameObject fullColere;
    public bool colereStacked;
    public bool pause;
    public bool isDead;

    //Movement
    Rigidbody2D rb;
    float mvtSpeed;
    public float startSpeed;
    //Jump
    public float jumpForce;
    Collider2D grounding;
    public float groundingRange;
    public LayerMask layerGround;
    public Transform groundDetector;
    public bool isGrounded;

    //Lvl Bougie
    private int checkPoint;
    public int nbCheckpoint;
    public GameObject lightBougie;
    bool isLightUp;
    bool alreadyLit;

    //Colere
    public float stackColere;
    public float rangeColere;
    public LayerMask layerColere;
    public GameObject flecheShooter;

    //Peur
    public float slowSpeed;

    //Culpabilité
    public Transform spawnPoint;

    //Tristesse
    public float stackTristesse;
    
    void Start()
    {
        fullColere.SetActive(false);
        mvtSpeed = startSpeed;
        rb = GetComponent<Rigidbody2D>();
        //colere
        if(menu2D.GetComponent<GameManager>().nbLvlDone == 4)
        {
            if(flecheShooter != null)
            {
                flecheShooter.SetActive(true);
            }
        }
        else
        {
            if (flecheShooter != null)
            {
                flecheShooter.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == true)
        {
            if (menu2D.GetComponent<GameManager>().nbLvlDone == 3)
            {
                
            }   
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
                if (isGrounded == true)
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
            if (jump == true)
            {
                if (isGrounded)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.deltaTime);
                }
            }

            if (stackColere >= 1)
            {
                stackColere = 1;
                if(colereStacked == false)
                {
                    fullColere.SetActive(true);
                    colereStacked = true;
                }
            }
            else
            {
                if (colereStacked == true)
                {
                    fullColere.SetActive(false);
                    colereStacked = false;
                }
            }
            colereBar.fillAmount = stackColere;
            //slowBlock
            if (grounding != null)
            {
                if (grounding.gameObject.tag.Equals("Slow"))
                {
                    if (mvtSpeed != slowSpeed)
                    {
                        mvtSpeed = slowSpeed;
                    }
                }
                else
                {
                    if (mvtSpeed != startSpeed)
                    {
                        mvtSpeed = startSpeed;
                    }
                }
            }

            if (menu2D.GetComponent<GameManager>().nbLvlDone == 5)
            {
                //allumage
                if (lightBougie != null)
                {
                    isLightUp = !isLightUp;
                }

                if (isLightUp)
                {
                    if (alreadyLit == false)
                    {
                        lightBougie.SetActive(true);
                        alreadyLit = true;
                    }
                }
                else
                {
                    if (alreadyLit == true)
                    {
                        lightBougie.SetActive(false);
                        alreadyLit = false;
                    }
                }

                if (checkPoint >= nbCheckpoint)
                {
                    menu2D.GetComponent<GameManager>().nbLvlDone += 1;
                    menu2D.GetComponent<SceneAndUI>().SceneLoader("Maison");
                }
            }
            if (menu2D.GetComponent<GameManager>().nbLvlDone == 4)
            {
                if (stackColere >= 1)
                {
                    Collider2D[] colereRange = Physics2D.OverlapCircleAll(transform.position, rangeColere, layerColere);
                    if (Input.GetKey(KeyCode.A))
                    {
                        for (int i = 0; i < colereRange.Length; i++)
                        {
                            GameObject target = colereRange[i].gameObject;
                            target.GetComponent<BlockDestructible>().BreakingAnim();
                            stackColere = 0;
                        }
                    }
                }
            }
        }
    }

    private void FixedUpdate()
    {
        //jump 
        grounding = Physics2D.OverlapCircle(groundDetector.position, groundingRange, layerGround); 
        isGrounded = Physics2D.OverlapCircle(groundDetector.position, groundingRange, layerGround);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            menu2D.GetComponent<SceneAndUI>().Retry();
        }
        if (collision.gameObject.tag.Equals("Finish"))
        {
            FinishLevel();
        }
        if (collision.gameObject.tag.Equals("checkPoint"))
        {
            checkPoint += 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Breakable"))
        {
            if (menu2D.GetComponent<GameManager>().nbLvlDone == 0)
            {
                grounding = null;
                isGrounded = false;
                collision.gameObject.GetComponent<BlockDestructible>().NormalDestruction();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundDetector.position, groundingRange);
    }
    public void RespawnCulpability()
    {
        transform.position = spawnPoint.position;
    }

    public void FinishLevel()
    {
        menu2D.GetComponent<GameManager>().nbLvlDone += 1;
        menu2D.GetComponent<SceneAndUI>().SceneLoader("Maison");
    }
}
