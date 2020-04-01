using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject gameManager;
    int nbLvl;
    //Jump
    public float modifiedJump;
    public float modifiedSpeed;
    public float modifiedGravity;

    // Update is called once per frame
    void Update()
    {
        nbLvl = gameManager.GetComponent<GameManager>().nbLvlDone;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if(nbLvl == 0)
            {
                collision.gameObject.GetComponent<Controller2D>().jumpForce = modifiedJump;
                collision.gameObject.GetComponent<Controller2D>().mvtSpeed = modifiedSpeed;
                collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = modifiedGravity;
            }

            if(nbLvl == 4)
            {
                collision.gameObject.GetComponent<Controller2D>().stackTristesse += 1;
            }
        }
    }
}
