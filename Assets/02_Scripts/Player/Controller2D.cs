using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller2D : MonoBehaviour
{

    //Animtion
    public Animator Anm;
    bool isWalking;
    bool isJumping;

    //General
    public GameObject menu2D;
    public GameObject camera2D;
    public Image colereBar;
    public GameObject fullColere;
    public bool colereStacked;
    public bool pause;
    public bool isDead;

    //Movement
    Rigidbody2D rb;
    public float mvtSpeed;
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
    public bool milieuCulpa;
    public Transform spawnPoint;

    //Tristesse
    public float stackTristesse;


    void Start()
    {
        LoadInfos();
        mvtSpeed = startSpeed;
        rb = GetComponent<Rigidbody2D>();
        //colere
        if(menu2D.GetComponent<GameManager>().nbLvlDone == 4)
        {
            fullColere.SetActive(false);
            if (flecheShooter != null)
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
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (h < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
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
                    rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                }
            }

            //Anim

            if (isGrounded)
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
                if (isJumping == true)
                {
                    Anm.SetBool("Jump", false);
                    isJumping = false;
                }
                if (h != 0)
                {
                    if(isWalking == false)
                    {
                        Anm.SetBool("Walk", true);
                        isWalking = true;
                    }
                }
                else
                {
                    if (isWalking == true)
                    {
                        Anm.SetBool("Walk", false);
                        isWalking = false;
                    }
                }
            }
            else
            {
                if (isJumping == false)
                {
                    Anm.SetBool("Jump", true);
                    isJumping = true;
                }
                if (rb.velocity.y >= 0) //verif quil saute et pas tombe
                {

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

                if (stackColere >= 1)
                {
                    stackColere = 1;
                    if (colereStacked == false)
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
                if(colereBar != null)
                {
                    colereBar.fillAmount = stackColere;
                }
            }
        }
        else
        {
            rb.velocity = new Vector2(0f, 0f);
            Anm.SetBool("Jump", false);
            Anm.SetBool("Walk", false);
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
            if (menu2D.GetComponent<GameManager>().nbLvlDone == 1)
            {
                collision.gameObject.GetComponent<Animator>().SetBool("Detected", true);
            }
            else
            {
                FinishLevel();
            }
        }
        if (collision.gameObject.tag.Equals("Marteau"))
        {
            if (milieuCulpa == true)
            {
                RespawnCulpability();
            }
            if (milieuCulpa == false)
            {
                TutoCulpability();
            }

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
        if (milieuCulpa == false)
        {
            milieuCulpa = true;
        }
    }
    public void TutoCulpability()
    {
        transform.position = new Vector3(-4, 0.6f, 0);
    }

    public void FinishLevel()
    {
        menu2D.GetComponent<GameManager>().nbLvlDone += 1;
        Debug.Log(menu2D.GetComponent<GameManager>().nbLvlDone);
        menu2D.GetComponent<GameManager>().lvlDoneForce();
        menu2D.GetComponent<SceneAndUI>().ActiveScene("Maison");
        menu2D.GetComponent<SceneAndUI>().SceneLoader("Maison");

    }

    public void LoadInfos()
    {
        SaveData data = SavingSystem.LoadData();

        string activeSceneName = data.scene;
        menu2D.GetComponent<SceneAndUI>().ActiveScene(activeSceneName);
    }
}
