using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2D : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    public GameObject Camera;
    public bool pause;

    //Movement
    public float forceMvt;
    public float maxSpeedGround;
    //Jump
    public float jumpForce;
    public int maxJump;
    public int nbJump;
    public bool isJumping;

    public Rigidbody2D Rigidbody { get => rigidbody; set => rigidbody = value; }


    // Start is called before the first frame update

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        pause = Camera.GetComponent<SceneAndUI>().pause;
        if (pause == false)
        {
            bool GoToMenu = Input.GetButtonDown("Cancel");
            bool attack = Input.GetButtonDown("Fire1");

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
                rigidbody.AddForce((Vector2.right * forceMvt) * h);
            }
            if (h == 0)
            {
            }


            if (rigidbody.velocity.x >= maxSpeedGround)
            {
                rigidbody.velocity = new Vector2(maxSpeedGround, rigidbody.velocity.y);
            }
            if (rigidbody.velocity.x <= -maxSpeedGround)
            {
                rigidbody.velocity = new Vector2(-maxSpeedGround, rigidbody.velocity.y);
            }

            // le saut

            if (nbJump < maxJump && jump == true)
            {
                Rigidbody.AddForce(Vector2.up * jumpForce);
                nbJump += 1;
                isJumping = true;
            }
        }

    }

    //Détecte les collisions(pour le jump et mort)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Saut
        if (collision.gameObject.tag.Equals("Ground"))
        {
            nbJump = 0;
            isJumping = false;
        }

    }
}
