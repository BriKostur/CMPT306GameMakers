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
    private Animator anime;
	private bool right;
	private bool inAir; // Flag to prevent the player from jumping infinitely
	//public Transform warpDestination;
	
    // Use this for initialization
    void Start()
    {
		phys = GetComponent<Rigidbody2D> ();
		//gameObject.transform.position = warpDestination.position; // Set spawn point
        anime = GetComponent<Animator>();
    }
	
    private void FixedUpdate()
    {
		if (!GetComponentInChildren<MagBoots> ().isActive) {
			transform.up = -Physics2D.gravity;
		}
    }

    // Update is called once per frame
    void Update()
    {
        //Jump code
		if (Input.GetKeyDown(KeyCode.Space)&&!inAir)
        {
			phys.velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x + jumpHeight * transform.up.x, GetComponent<Rigidbody2D>().velocity.y + jumpHeight * transform.up.y);
			inAir = true;
        }

		//Walk code
		curVec = phys.velocity;
		moveVec.x = moveSpeed * Input.GetAxis ("Horizontal") * transform.right.x;
		moveVec.y = moveSpeed * Input.GetAxis ("Horizontal") * transform.right.y;

		//Minimum speed code
		if (moveVec.magnitude < minVel) {
			moveVec.Normalize ();
			moveVec = moveVec * minVel;
		}
		//Maximum speed code
		if ((curVec.magnitude + moveVec.magnitude) > maxVel) {
			moveVec.Normalize ();
			moveVec = moveVec * (maxVel - curVec.magnitude);
		}

		//Apply calculated movement vector
		GetComponent<Rigidbody2D>().AddForce(moveVec);

		//Handle walking animation
		anime.SetFloat("Speed", (phys.velocity.y*transform.right.y + phys.velocity.x*transform.right.x));

		//Handle Jumping/Falling animation
		if (phys.velocity.y*transform.up.y + phys.velocity.x*transform.up.x>1||phys.velocity.y*transform.up.y + phys.velocity.x*transform.up.x<-1) {
			anime.SetBool ("Jump", true);
		} else {
			anime.SetBool ("Jump", false);
		}
    }
	 void OnCollisionStay2D (Collision2D collisionInfo)
 	{
		inAir = false;
 	}
 
 	void OnCollisionExit2D (Collision2D collisionInfo)
	 {
		inAir = true;
 	}

}
