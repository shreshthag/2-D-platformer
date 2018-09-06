using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontrol : MonoBehaviour {

	public GameObject target;
	public float followahead;
	private Vector3 targetposition;
	public float smoothing;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		targetposition = new Vector3 (target.transform.position.x, transform.position.y, transform.position.z);
		if (target.transform.localScale.x > 0f) {
			targetposition = new Vector3 (targetposition.x + followahead, targetposition.y, targetposition.z);
		} else {
			targetposition = new Vector3 (targetposition.x - followahead, targetposition.y, targetposition.z);
		}
		//transform.position = targetposition;
		transform.position = Vector3.Lerp(transform.position,targetposition,smoothing*Time.deltaTime);
	}
}
