using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WalkSounds : MonoBehaviour {

	public List<AudioClip> walkSounds = new List<AudioClip>();
	public float secondsBetweenSteps;

	private enum Foot {
		LEFT = 0,
		RIGHT
	};

	private Vector3 lastPos;
	private float timeOfNextStep;
	private AudioSource[] foot;
	private int footIndicator;
	public AudioSource leftFoot;
	public AudioSource rightFoot;

	private int lastSoundIndex;

	// Use this for initialization
	void Start () {
		lastPos = this.transform.position;
		timeOfNextStep = 0.0f;
		foot = new AudioSource[2];
		foot [(int)Foot.LEFT] = leftFoot;
		foot [(int)Foot.RIGHT] = rightFoot;
		footIndicator = 0;
		lastSoundIndex = -1;
	}
	
	// Update is called once per frame
	void Update () {
		if (timeOfNextStep < Time.fixedTime) {
			int soundToPlay;
			// Just avoid playing the same sound twice in a row.
			do {
				System.Random rnd = new System.Random ();
				soundToPlay = rnd.Next (walkSounds.Count);
			} while (soundToPlay == lastSoundIndex);
			lastSoundIndex = soundToPlay;

			footIndicator = footIndicator == (int)Foot.LEFT ? (int)Foot.RIGHT : (int)Foot.LEFT;
			timeOfNextStep = Time.fixedTime + secondsBetweenSteps;

			foot [footIndicator].PlayOneShot (walkSounds [soundToPlay]);
		}
	}
}
