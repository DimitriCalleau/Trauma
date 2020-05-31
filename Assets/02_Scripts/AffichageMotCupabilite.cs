using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffichageMotCupabilite : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public Sprite[] motsCulpabilite;
    public float speed;
    public float death;

    int randomSpawn1;
    int randomSpawn2;
    int randomSpawn3;
    int randomSpawn4;
    int randomSpawn5;

    int randomMot1;
    int randomMot2;
    int randomMot3;
    int randomMot4;
    int randomMot5;

    float timer1;
    float timer2;
    float timer3;
    float timer4;
    float timer5;

    public float timing1;
    public float timing2;
    public float timing3;
    public float timing4;
    public float timing5;

    SpriteRenderer rdr1;
    SpriteRenderer rdr2;
    SpriteRenderer rdr3;
    SpriteRenderer rdr4;
    SpriteRenderer rdr5;

    GameObject spawn1;
    GameObject spawn2;
    GameObject spawn3;
    GameObject spawn4;
    GameObject spawn5;

    bool stop1;
    bool stop2;
    bool stop3;
    bool stop4;
    bool stop5;

    void Start()
    {
        timer1 = timing1;
        timer2 = timing2;
        timer3 = timing3;
        timer4 = timing4;
        timer5 = timing5;
    }

    // Update is called once per frame
    void Update()
    {
        if (death >= 1)
        {
            speed = 0.5f * death;
            if (death >= 5)
            {
                speed = 2.5f;
            }
        }

        if (timer1 >= 0)
        {
            timer1 -= Time.deltaTime * speed;
        }
        if (timer2 >= 0)
        {
            timer2 -= Time.deltaTime * speed;
        }
        if (timer3 >= 0)
        {
            timer3 -= Time.deltaTime * speed;
        }
        if (timer4 >= 0)
        {
            timer4 -= Time.deltaTime * speed;
        }
        if (timer5 >= 0)
        {
            timer5 -= Time.deltaTime * speed;
        }

        if (timer1 <= 0)
        {
            if (rdr1 != null)
            {
                rdr1.sprite = null;
                stop1 = false;
            }
            if (stop1 == false)
            {
                randomSpawn1 = Random.Range(0, (spawnPoints.Length));
                randomMot1 = Random.Range(0, (motsCulpabilite.Length));
                spawn1 = spawnPoints[randomSpawn1];
                rdr1 = spawn1.GetComponent<SpriteRenderer>();
                rdr1.sprite = motsCulpabilite[randomMot1];
                timer1 = timing1;
                stop1 = true;
            }
        }

        if (timer2 <= 0)
        {
            if (rdr2 != null)
            {
                rdr2.sprite = null;
                stop2 = false;
            }
            if (stop2 == false)
            {
                randomSpawn2 = Random.Range(0, (spawnPoints.Length));
                randomMot2 = Random.Range(0, (motsCulpabilite.Length));
                spawn2 = spawnPoints[randomSpawn2];
                rdr2 = spawn1.GetComponent<SpriteRenderer>();
                rdr2.sprite = motsCulpabilite[randomMot2];
                timer2 = timing2;
                stop2 = true;
            }
        }

        if (timer3 <= 0)
        {
            if (rdr3 != null)
            {
                rdr3.sprite = null;
                stop3 = false;
            }
            if (stop3 == false)
            {
                randomSpawn3 = Random.Range(0, (spawnPoints.Length));
                randomMot3 = Random.Range(0, (motsCulpabilite.Length));
                spawn3 = spawnPoints[randomSpawn3];
                rdr3 = spawn3.GetComponent<SpriteRenderer>();
                rdr3.sprite = motsCulpabilite[randomMot3];
                timer3 = timing3;
                stop3 = true;
            }
        }

        if (timer4 <= 0)
        {
            if (rdr4 != null)
            {
                rdr4.sprite = null;
                stop4 = false;
            }
            if (stop4 == false)
            {
                randomSpawn4 = Random.Range(0, (spawnPoints.Length));
                randomMot4 = Random.Range(0, (motsCulpabilite.Length));
                spawn4 = spawnPoints[randomSpawn4];
                rdr4 = spawn4.GetComponent<SpriteRenderer>();
                rdr4.sprite = motsCulpabilite[randomMot4];
                timer4 = timing4;
                stop4 = true;
            }
        }

        if (timer5 <= 0)
        {
            if (rdr5 != null)
            {
                rdr5.sprite = null;
                stop5 = false;
            }
            if (stop5 == false)
            {
                randomSpawn5 = Random.Range(0, (spawnPoints.Length));
                randomMot5 = Random.Range(0, (motsCulpabilite.Length));
                spawn5 = spawnPoints[randomSpawn5];
                rdr5 = spawn5.GetComponent<SpriteRenderer>();
                rdr5.sprite = motsCulpabilite[randomMot5];
                timer5 = timing5;
                stop5 = true;
            }
        }
    }
}
/*
                if (randomMot3 == randomMot1)
                {
                    if (randomMot3 <= 1)
                    {
                        randomMot3 += 1;
                    }
                    if (randomMot3 >= motsCulpabilite.Length - 1)
                    {
                        randomMot3 -= 1;
                    }
                }
                if (randomMot3 == randomMot2)
                {
                    if (randomMot3 <= 1)
                    {
                        randomMot3 += 1;
                    }
                    if (randomMot3 >= motsCulpabilite.Length - 1)
                    {
                        randomMot3 -= 1;
                    }
                }


                if (randomSpawn3 == randomSpawn2)
                {
                    if (randomSpawn3 <= 1)
                    {
                        randomSpawn3 += 1;
                    }
                    if (randomSpawn3 >= spawnPoints.Length - 1)
                    {
                        randomSpawn3 -= 1;
                    }
                }
                if (randomSpawn3 == randomSpawn1)
                {
                    if (randomSpawn3 <= 1)
                    {
                        randomSpawn3 += 1;
                    }
                    if (randomSpawn3 >= spawnPoints.Length - 1)
                    {
                        randomSpawn3 -= 1;
                    }
                }
*/
