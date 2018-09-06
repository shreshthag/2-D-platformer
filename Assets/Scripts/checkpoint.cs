using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour {

	public Sprite flagclosed;
	public Sprite flagopen;

	private SpriteRenderer spriterender;
	public bool checkpointactive;

	// Use this for initialization
	void Start () {
		spriterender = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			spriterender.sprite = flagopen;
			checkpointactive = true;
		}
	}

}
