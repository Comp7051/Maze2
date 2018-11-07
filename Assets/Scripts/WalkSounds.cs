using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WalkSounds : MonoBehaviour {

	public List<AudioClip> walkSounds = new List<AudioClip>();

	private enum Foot {
		LEFT = 0,
		RIGHT
	};

	private float timeOfLastStep;
	private AudioSource[] foot;
	private int footIndicator;
	public AudioSource leftFoot;
	public AudioSource rightFoot;

	private int lastSoundIndex;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		timeOfLastStep = 0.0f;
		foot = new AudioSource[2];
		foot [(int)Foot.LEFT] = leftFoot;
		foot [(int)Foot.RIGHT] = rightFoot;
		footIndicator = 0;
		lastSoundIndex = -1;
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.CompareTag ("Player")) {
			float speed = rb.velocity.magnitude;
			float delay = 0.25f;

			if (speed > 2.0f) {
				if (speed > 30.0f) {
					delay *= 0.7f;
				} else if (speed > 10.0f) {
					delay /= 0.8f;
				} else if (speed > 4.0f) {
					delay /= 0.9f;
				} else if (speed > 3.0f) {
					delay /= 1.0f;
				} else if (speed > 2.0f && speed <= 3.0f) {
					delay *= 1.2f;
				}

				if (Time.fixedTime > timeOfLastStep + delay) {
					timeOfLastStep = Time.fixedTime;

					footIndicator = footIndicator == (int)Foot.LEFT ? (int)Foot.RIGHT : (int)Foot.LEFT;
					FootStep (footIndicator);
				}
			}
		}
	}

	public void FootStep(int footIndicator) {
		int soundToPlay;
		// Just avoid playing the same sound twice in a row.
		do {
			System.Random rnd = new System.Random ();
			soundToPlay = rnd.Next (walkSounds.Count);
		} while (soundToPlay == lastSoundIndex);
		lastSoundIndex = soundToPlay;

		foot [footIndicator].PlayOneShot (walkSounds [soundToPlay]);
	}
}
