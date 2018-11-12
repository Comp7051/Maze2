using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour {

	public float lifeTime;
	public AudioSource bounce;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Player") {
		} else if(col.gameObject.tag == "Enemy") {
		} else {
			bounce.Play ();
		}
	}
}
