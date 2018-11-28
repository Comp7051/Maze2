using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour {

	public GameObject ball;
	public float velocity;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (false/*Input.GetButtonDown ("Fire1")*/) {
			GameObject clone;
			clone = Instantiate (ball, Camera.main.transform.position, Camera.main.transform.rotation);//, transform.forward);
			clone.GetComponent<Rigidbody>().velocity = clone.transform.forward * velocity;
			Physics.IgnoreCollision(clone.GetComponent<Collider>(), transform.GetComponent<Collider>());
		}
	}
}