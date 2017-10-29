using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	Vector2 moveVec;
	Vector2 curVec;
	Rigidbody2D phys;

	public float maxVel = 16;
	public float minVel = 4;
    public float moveSpeed;
    public float jumpHeight;
  //  public float groundCheckRadius;
   // public Transform groundCheck;
 //   public LayerMask maskGround;
  //  private bool grounded;
    private Animator anime;
	private bool right;

    // Use this for initialization
    void Start()
    {
		phys = GetComponent<Rigidbody2D> ();
        anime = GetComponent<Animator>();
		moveVec.x = 0;
		moveVec.y = 0;
    }

    private void FixedUpdate()
    {
		if (!GetComponentInChildren<MagBoots> ().isActive) {
			transform.up = -Physics2D.gravity;
		}
  //      grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, maskGround);
    }
		
    // Update is called once per frame
    void Update()
    {
		

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            anime.SetBool("Jump", true);
        }

		//Alternate movement code
		curVec = phys.velocity;
		moveVec.x = moveSpeed * Input.GetAxis ("Horizontal") * transform.right.x;
		moveVec.y = moveSpeed * Input.GetAxis ("Horizontal") * transform.right.y;
		/*if (moveVec.x < minVel && moveVec.x > -minVel && moveVec.x!=0) {
			if (moveVec.x > 0){ 
				moveVec.x = minVel;
			}else{
				moveVec.x = -minVel;
			}
		}

		if ((curVec.x + moveVec.x) > maxVel) {
			moveVec.x = maxVel- curVec.x;
		}
		if (curVec.x + moveVec.x < -maxVel) {
			moveVec.x = -maxVel - curVec.x;
		}*/
		GetComponent<Rigidbody2D>().AddForce(moveVec); //*/

        /* if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            //anime.SetFloat("Speed", GetComponent<Rigidbody2D>().velocity.x);

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }//*/

        anime.SetFloat("Speed", GetComponent<Rigidbody2D>().velocity.x);



    }

     void OnCollisionEnter2D(Collision2D coll)
    {
        anime.SetBool("Jump", false);
    }
}
