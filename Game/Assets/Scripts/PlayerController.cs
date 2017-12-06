using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	Vector2 moveVec;
	Vector2 curVec;
	Rigidbody2D phys;
	public AudioSource jumpSound;

	public float maxVel = 16;
	public float minVel = 4;
    public float moveSpeed;
    public float jumpHeight;
	public float currSpeed; // For use in animatons
    private Animator anime;
	private bool right;
	private bool inAir; // Flag to prevent the player from jumping infinitely
	public bool canGrav;
	public int directionFacing; // Determine direction character is facing to point gun the correct way (0 is left, 1 is right, relative to character);
	//public Transform warpDestination;
	public bool playJumpSound = false;
	
    // Use this for initialization
    void Start()
    {
		phys = GetComponent<Rigidbody2D> ();
		//gameObject.transform.position = warpDestination.position; // Set spawn point
        anime = GetComponent<Animator>();
		directionFacing = 1;
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
			playJumpSound = true;
        }

		//Walk code
		curVec = phys.velocity;
		moveVec.x = moveSpeed * Input.GetAxis ("Horizontal") * transform.right.x;
		moveVec.y = moveSpeed * Input.GetAxis ("Horizontal") * transform.right.y;

		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			directionFacing = 1; // Face gun right
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			directionFacing = 0; // Face gun left
		}

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
		currSpeed =(phys.velocity.y*transform.right.y + phys.velocity.x*transform.right.x);
		anime.SetFloat("Speed", currSpeed);

		//Handle Jumping/Falling animation
		if (phys.velocity.y*transform.up.y + phys.velocity.x*transform.up.x>1||phys.velocity.y*transform.up.y + phys.velocity.x*transform.up.x<-1) {
			anime.SetBool ("Jump", true);
		} else {
			anime.SetBool ("Jump", false);
		}

		// Play jump sound
		if (playJumpSound == true) {
			playJumpSound = false;
			jumpSound.Play ();
		}
    }
	 void OnCollisionStay2D (Collision2D collisionInfo)
 	{
		inAir = false;
		if (collisionInfo.gameObject.tag=="GravPlat") {
			canGrav = true;
		}
 	}
 
 	void OnCollisionExit2D (Collision2D collisionInfo)
	{
		inAir = true;
		canGrav = false;
 	}

}
