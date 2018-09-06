using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controls : MonoBehaviour {

	public float movespeed;
	public float jumpspeed;

	private Rigidbody2D myrigidbody;
	private Animator myanime;

	public Transform groundcheck;
	public float groundcheckradius;
	public LayerMask whatisground;
	public Vector3 respawnpos;

	private bool isGrounded;
	// Use this for initialization
	void Start () {
		myanime = GetComponent<Animator> ();
		myrigidbody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		isGrounded = Physics2D.OverlapCircle (groundcheck.position, groundcheckradius, whatisground);


		if (Input.GetAxisRaw ("Horizontal") > 0f ) {
			myrigidbody.velocity = new Vector3 (movespeed, myrigidbody.velocity.y, 0f);
			transform.localScale = new Vector3 (1f, 1f, 1f);
		} else if (Input.GetAxisRaw ("Horizontal") < 0f ) {
			myrigidbody.velocity = new Vector3 (-movespeed, myrigidbody.velocity.y, 0f);
			transform.localScale = new Vector3 (-1f, 1f, 1f);
		} else {
			myrigidbody.velocity = new Vector3 (0f, myrigidbody.velocity.y, 0f);
		}

		if (Input.GetButtonDown ("Jump") && isGrounded) {	
			myrigidbody.velocity = new Vector3 (myrigidbody.velocity.x, jumpspeed, 0f);
		}

		myanime.SetFloat ("speed", Mathf.Abs (myrigidbody.velocity.x));
		myanime.SetBool ("ground", isGrounded);
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "killplane") {
			//gameObject.SetActive (false);
			transform.position = respawnpos;
		}
		if (other.tag == "checkpoint") {
			respawnpos = other.transform.position;
		}
	}

}
