/*
 * Music by Eric Matyas
 * www.soundimage.org
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	public AudioSource dayMusic;
	public AudioSource nightMusic;

	private static bool fogState = false;
	private static bool nightState = false;
	private static bool updateNeeded = true;
	private static bool musicPlaying = true;

	private float dayVolumeNormal;
	private float nightVolumeNormal;

	// Use this for initialization
	void Start () {
		dayVolumeNormal = dayMusic.volume;
		nightVolumeNormal = nightMusic.volume;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.M) || Input.GetKeyUp (KeyCode.Joystick1Button2)) {
			musicPlaying = !musicPlaying;
			updateNeeded = true;
		}
		
		if (updateNeeded) {
			UpdateMusic ();
			updateNeeded = false;
		}
	}

	private void UpdateMusic() {
		if (!musicPlaying) {
			if (dayMusic.isPlaying)
				dayMusic.Stop ();
			if (nightMusic.isPlaying)
				nightMusic.Stop ();

			return;
		}

		if (nightState) {
			if (dayMusic.isPlaying) {
				dayMusic.Stop ();
			}
			if (!nightMusic.isPlaying) {
				nightMusic.Play ();
			}
		} else {
			if (nightMusic.isPlaying) {
				nightMusic.Stop ();
			}
			if (!dayMusic.isPlaying) {
				dayMusic.Play ();
			}
		}

		if (fogState) {
			dayMusic.volume = dayVolumeNormal / 2;
			nightMusic.volume = nightVolumeNormal / 2;
		} else {
			dayMusic.volume = dayVolumeNormal;
			nightMusic.volume = nightVolumeNormal;
		}
	}

	public static void FogState(bool fogState) {
		MusicManager.fogState = fogState;
		updateNeeded = true;
	}

	public static void NightState(bool nightState) {
		MusicManager.nightState = nightState;
		updateNeeded = true;
	}
}
