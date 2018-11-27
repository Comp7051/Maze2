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

	private GameObject player;
	private GameObject enemy;

	private float maxDistance;

	// Use this for initialization
	void Start () {
		dayVolumeNormal = dayMusic.volume;
		nightVolumeNormal = nightMusic.volume;

		player = GameObject.FindGameObjectWithTag ("Player");
		enemy = GameObject.FindGameObjectWithTag ("Enemy");

		GenerateMaze mazeScript = GameObject.FindGameObjectWithTag ("Maze").GetComponent<GenerateMaze> ();
		Bounds cellBounds = GameObject.FindGameObjectWithTag ("Cell").GetComponent<Renderer>().bounds;

		Vector3 mazeBounds = new Vector3 (cellBounds.size.x * mazeScript.width, cellBounds.size.y * mazeScript.width, cellBounds.size.z * mazeScript.width);
		maxDistance = Mathf.Sqrt (Mathf.Pow (mazeBounds.x, 2) + Mathf.Pow (mazeBounds.z, 2)); // Hypotenuse of the maze's total dimensions
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

		float musicModulation = (1.0f - Vector3.Distance (player.transform.position, enemy.transform.position) / maxDistance);
		if (fogState) {
			dayMusic.volume = (dayVolumeNormal /2) * musicModulation;
			nightMusic.volume = (nightVolumeNormal /2) * musicModulation;
		} else {
			dayMusic.volume = dayVolumeNormal * musicModulation;
			nightMusic.volume = nightVolumeNormal * musicModulation;
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

		/*if (fogState) {
			dayMusic.volume = dayVolumeNormal / 2;
			nightMusic.volume = nightVolumeNormal / 2;
		} else {
			dayMusic.volume = dayVolumeNormal;
			nightMusic.volume = nightVolumeNormal;
		}*/
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
