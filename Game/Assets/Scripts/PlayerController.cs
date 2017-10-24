using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpHeight;
    //public float groundCheckRadius;
    //public Transform groundCheck;
    //public LayerMask maskGround;
    //private bool grounded;
    private Animator anime;


    // Use this for initialization
    void Start()
    {
        anime = GetComponent<Animator>();
    }
 
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            anime.SetBool("Jump", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            //anime.SetFloat("Speed", GetComponent<Rigidbody2D>().velocity.x);

        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

        anime.SetFloat("Speed", GetComponent<Rigidbody2D>().velocity.x);



    }

     void OnCollisionEnter2D(Collision2D coll)
    {
        anime.SetBool("Jump", false);
    }
}
