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
	public Transform warpDestination;
	
    // Use this for initialization
    void Start()
    {
		phys = GetComponent<Rigidbody2D> ();
		inAir = false;
		gameObject.transform.position = warpDestination.position; // Set spawn point
        anime = GetComponent<Animator>();
		moveVec.x = 0;
		moveVec.y = 0;
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            anime.SetBool("Jump", true);
        }

		curVec = phys.velocity;
		moveVec.x = moveSpeed * Input.GetAxis ("Horizontal") * transform.right.x;
		moveVec.y = moveSpeed * Input.GetAxis ("Horizontal") * transform.right.y;
		if (moveVec.magnitude < minVel) {
			moveVec.Normalize ();
			moveVec = moveVec * minVel;
		}
		if ((curVec.magnitude + moveVec.magnitude) > maxVel) {
			moveVec.Normalize ();
			moveVec = moveVec * (maxVel - curVec.magnitude);
		}
		GetComponent<Rigidbody2D>().AddForce(moveVec);
		
        anime.SetFloat("Speed", GetComponent<Rigidbody2D>().velocity.x);
    }

     void OnCollisionEnter2D(Collision2D coll)
    {
		inAir = false; // We are no longer jumping
        anime.SetBool("Jump", false);
    }
}
