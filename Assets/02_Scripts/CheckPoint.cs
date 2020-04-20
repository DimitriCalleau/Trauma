using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject gameManager;
    int nbLvl;
    bool state;
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
        state = false;
        nbLvl = gameManager.GetComponent<GameManager>().nbLvlDone;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag.Equals("Player"))
        {
            if(nbLvl == 0)
            {
                if(state == false)
                {
                    collision.gameObject.GetComponent<Controller2D>().jumpForce = modifiedJump;
                    collision.gameObject.GetComponent<Controller2D>().mvtSpeed = modifiedSpeed;
                    collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = modifiedGravity;
                    collision.gameObject.GetComponent<Controller2D>().camera2D.GetComponent<Camera>().orthographicSize = cameraDistanceAfter;
                    state = true;
                }
                if(state == true)
                {
                    collision.gameObject.GetComponent<Controller2D>().jumpForce = jump;
                    collision.gameObject.GetComponent<Controller2D>().mvtSpeed = speed;
                    collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = gravity;
                    collision.gameObject.GetComponent<Controller2D>().camera2D.GetComponent<Camera>().orthographicSize = cameraDistanceBefore;
                    state = false;
                }

            }

            if(nbLvl == 4)
            {
                collision.gameObject.GetComponent<Controller2D>().stackTristesse += 1;
                Destroy(this.gameObject);
            }
        }
    }
}
