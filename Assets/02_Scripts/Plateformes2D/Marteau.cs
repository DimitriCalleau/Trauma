using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marteau : MonoBehaviour
{
    public SpriteRenderer sprRdr;
    public Sprite open;
    public Sprite closed;
    public BoxCollider2D block;
    public GameObject kill;
    public float timer;
    public float timingOpen;
    public float timingClosed;
    public int phase;
    // Start is called before the first frame update
    void Start()
    {
        kill.SetActive(true);
        block.isTrigger = false;
        timer = timingClosed;
        sprRdr.sprite = closed;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            if (phase == 0)
            {
                kill.SetActive(false);
                block.isTrigger = true;
                timer = timingOpen;
                phase = 1;
                sprRdr.sprite = open;
            }
        }

        if (timer <= 0)
        {
            if (phase == 1)
            {
                kill.SetActive(true);
                block.isTrigger = false;
                timer = timingClosed;
                phase = 0;
                sprRdr.sprite = closed;
            }
        }
    }
}
