using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpHeight;
    private Animator anime;
	private bool inAir; // Flag to prevent the player from jumping infinitely
	public Transform warpDestination;


    // Use this for initialization
    void Start()
    {
		inAir = false;
		gameObject.transform.position = warpDestination.position; // Set spawn point
        anime = GetComponent<Animator>();
    }
 
    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey (KeyCode.Space))
		{
			if (inAir == false) // If we are not already jumping
			{
				inAir = true; // We are now jumping
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpHeight);
				anime.SetBool ("Jump", true);
			}
		}
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        anime.SetFloat("Speed", GetComponent<Rigidbody2D>().velocity.x);
    }

     void OnCollisionEnter2D(Collision2D coll)
    {
		inAir = false; // We are no longer jumping
        anime.SetBool("Jump", false);
    }
}
