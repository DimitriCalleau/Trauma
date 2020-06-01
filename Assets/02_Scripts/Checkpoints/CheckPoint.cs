using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject gameManager;
    int nbLvl;
    public int state;
    public bool done;
    //Jump
    public float jump;
    public float speed;
    public float gravity;
    public float modifiedJump;
    public float modifiedSpeed;
    public float modifiedGravity;

    public int cameraDistanceBefore;
    public int cameraDistanceAfter;

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
                if (state == 0)
                {
                    if (done == false)
                    {
                        state = 1;
                        collision.gameObject.GetComponent<Controller2D>().jumpForce = modifiedJump;
                        collision.gameObject.GetComponent<Controller2D>().mvtSpeed = modifiedSpeed;
                        collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = modifiedGravity;
                        collision.gameObject.GetComponent<Controller2D>().camera2D.GetComponent<Camera>().orthographicSize = cameraDistanceAfter;
                        done = true;
                    }
                }
                if (state == 1)
                {
                    if (done == false)
                    { 
                        collision.gameObject.GetComponent<Controller2D>().jumpForce = jump;
                        collision.gameObject.GetComponent<Controller2D>().mvtSpeed = speed;
                        collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = gravity;
                        collision.gameObject.GetComponent<Controller2D>().camera2D.GetComponent<Camera>().orthographicSize = cameraDistanceBefore;
                        state = 0;
                        done = true;
                    }

                }
            }

            if(nbLvl == 4)
            {
                collision.gameObject.GetComponent<Controller2D>().stackTristesse += 1;
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            done = false;
        }
    }
}
