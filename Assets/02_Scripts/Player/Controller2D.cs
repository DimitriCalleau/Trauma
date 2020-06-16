﻿using System.Collections;
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
    public GameObject endingAnimator;
    public GameObject camera2D;
    public GameObject insulte;

    public bool pause;
    public bool isDead;
    public bool nextDeath;

    //Movement
    Rigidbody2D rb;
    public float mvtSpeed;
    public float startSpeed;

    //Jump

    public LayerMask layerGround;
    public Transform groundDetector;
    public AudioSource jumpSound;

    public float jumpForce;
    public float groundingRange;
    public bool isGrounded;

    Collider2D grounding;


    //Colere
    bool laColere;
    public bool finColere;
    public bool fullDestruction;

    public float stackColere;
    public float rangeColere;
    public float rangeFinColere;
    int compteurFleche;
    bool stopFlammeActivating;

    public LayerMask layerColere;
    public GameObject flecheShooter;
    public GameObject zone;
    public ParticleSystem explosionColere;
    public ParticleSystem explosionFinColere;
    public AudioSource explodingSound;
    public GameObject pressA;
    public GameObject[] flammes;
    GameObject instanceExplosion;
    //Peur
    public float slowSpeed;
    public ParticleSystem fumeeSlow;

    //Culpabilité
    public bool milieuCulpa;
    public Transform spawnPoint;

    //Tristesse

    public int tristesseChangeAnim1;
    public int tristesseChangeAnim2;

    bool animChanged1;
    bool animChanged2;

    bool finTristesse;

    float ratioAvancement;
    public float ratioTristesse;
    public Animator Anim1;
    public Animator Anim2;
    public Animator Anim3;
    public Animator Anim4;

    public GameObject endingPosition;

    //Flamme FX
    public Transform positionLightBougie1;
    public Transform positionLightBougie2;
    public Transform positionLightBougie3;
    public Transform positionLightBougie4;

    /*public GameObject lightBougie;
    public ParticleSystem lightBougieAlpha;
    public ParticleSystem lightBougieAdd;
    public ParticleSystem lightBougieSparks;*/
    public GameObject fire;

    //Cire FX
    public ParticleSystem cireCreationGoutte;

    public AudioSource fireSound;

    void Start()
    {
        LoadInfos();
        mvtSpeed = startSpeed;
        rb = GetComponent<Rigidbody2D>();
        nextDeath = false;

        //colere
        if(fumeeSlow != null)
        {
            fumeeSlow.Stop();
        }
        if(menu2D.GetComponent<GameManager>().nbLvlDone == 4)
        {
            zone.SetActive(false);
            pressA.SetActive(false);
            DesactivateFlammes();
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
        if(menu2D.GetComponent<GameManager>().nbLvlDone == 5)
        {
            Anim2.gameObject.SetActive(false);
            Anim3.gameObject.SetActive(false);
            Anim4.gameObject.SetActive(false);
        }
    }

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
            if(finTristesse == false)
            {
                if (Input.GetKey(KeyCode.M))
                {
                    FinishLevel();
                }
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

                if (jump == true)
                {
                    if (isGrounded)
                    {
                        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                        jumpSound.Play();
                    }
                }

                //Potit truc test shake cam

                if (Input.GetKey(KeyCode.P))
                {
                    camera2D.GetComponent<CameraFollow>().CameraShake(0.5f, 0.5f);
                }

                if (isGrounded)
                {
                    if (grounding.gameObject.tag.Equals("Slow"))
                    {
                        if (mvtSpeed != slowSpeed)
                        {
                            if (fumeeSlow != null)
                            {
                                fumeeSlow.Play();
                            }
                            mvtSpeed = slowSpeed;
                        }
                    }
                    else
                    {
                        if (mvtSpeed != startSpeed)
                        {
                            if (fumeeSlow != null)
                            {
                                fumeeSlow.Stop();
                            }
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
                        if (isWalking == false)
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
                    ratioAvancement = endingPosition.GetComponent<PourcentageNiveau>().ratio;
                    if (ratioAvancement < tristesseChangeAnim1)
                    {
                        if (positionLightBougie1 != null)
                        {
                            fire.transform.position = positionLightBougie1.position;
                        }
                    }
                    if (ratioAvancement >= tristesseChangeAnim1)
                    {
                        if (animChanged1 == false)
                        {
                            Anim2.gameObject.SetActive(true);
                            Anm = Anim2;
                            Anim1.gameObject.SetActive(false);
                            animChanged1 = true;

                            var emissionCire = cireCreationGoutte.GetComponent<ParticleSystem>().emission;
                            emissionCire.rateOverTime = 8f;
                        }
                        if (positionLightBougie2 != null)
                        {
                            fire.transform.position = positionLightBougie2.position;
                        }
                    }
                    if (ratioAvancement >= tristesseChangeAnim2)
                    {
                        if (animChanged2 == false)
                        {
                            Anim3.gameObject.SetActive(true);
                            Anm = Anim3;
                            Anim2.gameObject.SetActive(false);
                            animChanged2 = true;

                            var emissionCire = cireCreationGoutte.GetComponent<ParticleSystem>().emission;
                            emissionCire.rateOverTime = 15f;
                        }
                        if (positionLightBougie3 != null)
                        {
                            fire.transform.position = positionLightBougie3.position;
                        }

                        
                        if (ratioAvancement >= ratioTristesse)
                        {
                            StartCoroutine(FinTristesse());
                        }
                    }


                }
                if (menu2D.GetComponent<GameManager>().nbLvlDone == 4)
                {
                    if (finColere == false)
                    {
                        if (laColere == true)
                        {
                            mvtSpeed = 0;
                        }
                        if (stackColere >= 8)
                        {
                            pressA.SetActive(true);

                            Collider2D[] colereRange = Physics2D.OverlapCircleAll(zone.transform.position, rangeColere, layerColere);

                            if (Input.GetKey(KeyCode.A))
                            {
                                camera2D.GetComponent<CameraFollow>().CameraShake(0.5f, 0.5f);
                                pressA.SetActive(false);
                                if (explodingSound != null)
                                {
                                    explodingSound.Play();
                                }
                                DesactivateFlammes();
                                Anm.SetBool("Colere", true);
                                laColere = true;
                                stackColere = 0;
                                if (explosionColere != null)
                                {
                                    Instantiate(explosionColere, zone.transform.position, Quaternion.identity);
                                }
                                for (int i = 0; i < colereRange.Length; i++)
                                {
                                    GameObject target = colereRange[i].gameObject;
                                    target.GetComponent<BlockDestructible>().BreakingAnim();
                                }
                                StartCoroutine(StopAnmColere());
                            }
                        }
                    }
                    else
                    {
                        if (stopFlammeActivating == false)
                        {
                            flammes[0].SetActive(true);
                            flammes[1].SetActive(true);
                            flammes[2].SetActive(true);
                            flammes[3].SetActive(true);
                            flammes[4].SetActive(true);
                            flammes[5].SetActive(true);
                            flammes[6].SetActive(true);
                            flammes[7].SetActive(true);
                            stopFlammeActivating = false;
                        }

                        Collider[] colereFinRange = Physics.OverlapSphere(zone.transform.position, 30, layerGround);

                        if (fullDestruction == true)
                        {
                            for (int i = 0; i < colereFinRange.Length; i++)
                            {
                                GameObject target = colereFinRange[i].gameObject;
                                Destroy(target.gameObject);
                            }
                            StartCoroutine(FinColere());
                        }
                    }
                }
            }
            else
            {
                rb.velocity = new Vector2(0 , 0);
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
            if(nextDeath == true)
            {
                FinishLevel();
            }
            else
            {
                menu2D.GetComponent<SceneAndUI>().Retry();
            }
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
        if (collision.gameObject.tag.Equals("Peur"))
        {
            nextDeath = true;
        }
        if (collision.gameObject.tag.Equals("FinColere"))
        {
            finColere = true;
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
        if(menu2D.GetComponent<GameManager>().nbLvlDone == 4)
        {
            Gizmos.DrawWireSphere(zone.transform.position, rangeColere);
        }
    }

    public void RespawnCulpability()
    {
        insulte.GetComponent<AffichageMotCupabilite>().death += 1;
        transform.position = spawnPoint.position;
        if (milieuCulpa == false)
        {
            milieuCulpa = true;
        }
    }

    public void TutoCulpability()
    {
        transform.position = new Vector3(-4, 0.6f, 0);
        insulte.GetComponent<AffichageMotCupabilite>().death += 1;
    }

    public IEnumerator StopAnmColere()
    {
        yield return new WaitForSeconds(1);
        Anm.SetBool("Colere", false);
        laColere = false;
    }

    public IEnumerator FinColere()
    {
        yield return new WaitForSeconds(4);
        FinishLevel();
    }

    public IEnumerator FinTristesse()
    {
        finTristesse = true;
        float taille = 0;
        float ratioReduc = 0.005f;
        /*
        var shapeAlpha = lightBougieAlpha.GetComponent<ParticleSystem>().shape;
        var shapeAdd = lightBougieAdd.GetComponent<ParticleSystem>().shape;
        var shapeSparks = lightBougieSparks.GetComponent<ParticleSystem>().shape;
        */
        Anim4.gameObject.SetActive(true);
        Anm = Anim4;
        Anim3.gameObject.SetActive(false);

        cireCreationGoutte.Stop();

        if (positionLightBougie4 != null)
        {
            fire.transform.position = positionLightBougie4.position;
        }

        //Tentative de Reduction du feu

        while (taille <= 0.95)
        {
            fire.GetComponent<MeshRenderer>().material.SetFloat("_Flame_Opacity", taille);
            taille += ratioReduc;
            yield return new WaitForSeconds(0.01f);
            /*
            var lightBougieAddSize = lightBougieAdd.main.startSize;
            var lightBougieAlphaSize = lightBougieAlpha.main.startSize;
            var lightBougieSparksSpeed = lightBougieSparks.main.startSpeed;
            var lightBougieAddLF = lightBougieAdd.main.startLifetime;
            var lightBougieAlphaLF = lightBougieAlpha.main.startLifetime;
            var lightBougieSparksLF = lightBougieSparks.main.startLifetime;

            lightBougieAddSize.constant -= ratioReduc;
            lightBougieAddLF.constantMin -= ratioReduc;
            lightBougieAddLF.constantMax -= ratioReduc;
            lightBougieAlphaSize.constant -= ratioReduc;
            lightBougieAlphaLF.constantMin -= ratioReduc;
            lightBougieAlphaLF.constantMax -= ratioReduc;
            lightBougieSparksSpeed.constant -= ratioReduc;
            lightBougieSparksLF.constantMin -= ratioReduc;
            lightBougieSparksLF.constantMax -= ratioReduc;
            */
        }

        if(taille >= 0.95)
        {
            taille = 0.99f;
            fire.GetComponent<MeshRenderer>().material.SetFloat("_Flame_Opacity", taille);
            yield return new WaitForSeconds(1);
            taille = 1;
            fire.GetComponent<MeshRenderer>().material.SetFloat("_Flame_Opacity", taille);
            yield return new WaitForSeconds(1);
            fire.SetActive(false);
            yield return new WaitForSeconds(2);
            FinishLevel();
        }
    }

    public void ActivateFlammes()
    {
        if (stackColere >= 1)
        {
            flammes[0].SetActive(true);
        }
        if (stackColere >= 2)
        {
            flammes[0].SetActive(true);
            flammes[1].SetActive(true);
        }
        if (stackColere >= 3)
        {
            flammes[0].SetActive(true);
            flammes[1].SetActive(true);
            flammes[2].SetActive(true);
        }
        if (stackColere >= 4)
        {
            flammes[0].SetActive(true);
            flammes[1].SetActive(true);
            flammes[2].SetActive(true);
            flammes[3].SetActive(true);
        }
        if (stackColere >= 5)
        {
            flammes[0].SetActive(true);
            flammes[1].SetActive(true);
            flammes[2].SetActive(true);
            flammes[3].SetActive(true);
            flammes[4].SetActive(true);
        }
        if (stackColere >= 6)
        {
            flammes[0].SetActive(true);
            flammes[1].SetActive(true);
            flammes[2].SetActive(true);
            flammes[3].SetActive(true);
            flammes[4].SetActive(true);
            flammes[5].SetActive(true);
        }
        if (stackColere >= 7)
        {
            flammes[0].SetActive(true);
            flammes[1].SetActive(true);
            flammes[2].SetActive(true);
            flammes[3].SetActive(true);
            flammes[4].SetActive(true);
            flammes[5].SetActive(true);
            flammes[6].SetActive(true);
        }
        if (stackColere >= 8)
        {
            flammes[0].SetActive(true);
            flammes[1].SetActive(true);
            flammes[2].SetActive(true);
            flammes[3].SetActive(true);
            flammes[4].SetActive(true);
            flammes[5].SetActive(true);
            flammes[6].SetActive(true);
            flammes[7].SetActive(true);
        }
    }

    public void DesactivateFlammes()
    {
        flammes[0].SetActive(false);
        flammes[1].SetActive(false);
        flammes[2].SetActive(false);
        flammes[3].SetActive(false);
        flammes[4].SetActive(false);
        flammes[5].SetActive(false);
        flammes[6].SetActive(false);
        flammes[7].SetActive(false);
    }
    
    public void FinColereExplosion()
    {
        compteurFleche += 1;
        camera2D.GetComponent<CameraFollow>().CameraShake(0.5f, 5);
        if (compteurFleche == 1)
        {
            zone.SetActive(true);
        }
        if (explodingSound != null)
        {
            explodingSound.Play();
        }
        if (explosionColere != null)
        {
            explosionFinColere.gameObject.transform.localScale = explosionFinColere.gameObject.transform.localScale * Mathf.Pow(1.015f, compteurFleche);
            explosionFinColere.Play();
        }
        if (compteurFleche >= 18)
        {
            rangeFinColere = rangeColere * Mathf.Pow(1.015f, compteurFleche);
            fullDestruction = true;
        }
    }

    public void Tristesse()
    {
        
    }

    public void FinishLevel()
    {
        menu2D.GetComponent<GameManager>().nbLvlDone += 1;
        menu2D.GetComponent<GameManager>().lvlDoneForce();
        menu2D.GetComponent<SceneAndUI>().ActiveScene("Maison");
        menu2D.GetComponent<SceneAndUI>().SceneLoader("Maison");
    }

    public void LaunchEndingAnimation()
    {
        pause = true;

        if(menu2D.GetComponent<GameManager>().nbLvlDone == 0)
        {
            endingAnimator.GetComponent<Animator>().SetBool("Joie", true);
        }
        if(menu2D.GetComponent<GameManager>().nbLvlDone == 1)
        {
            endingAnimator.GetComponent<Animator>().SetBool("Incomprehension", true);
        }
        if(menu2D.GetComponent<GameManager>().nbLvlDone == 2)
        {
            endingAnimator.GetComponent<Animator>().SetBool("Peur", true);
        }
        if(menu2D.GetComponent<GameManager>().nbLvlDone == 3)
        {
            endingAnimator.GetComponent<Animator>().SetBool("Culpabilite", true);
        }
        if(menu2D.GetComponent<GameManager>().nbLvlDone == 4)
        {
            endingAnimator.GetComponent<Animator>().SetBool("Colere", true);
        }
        if(menu2D.GetComponent<GameManager>().nbLvlDone == 5)
        {
            endingAnimator.GetComponent<Animator>().SetBool("Tristesse", true);
        }
    }

    public void LoadInfos()
    {
        SaveData data = SavingSystem.LoadData();

        string activeSceneName = data.scene;
        menu2D.GetComponent<SceneAndUI>().ActiveScene(activeSceneName);
    }
}
