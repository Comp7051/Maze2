using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderManager : MonoBehaviour {

	private float ambientIntensity;
	public float ambientIntensityDay;
	public float ambientIntensityNight;

	// Use this for initialization
	void Start () {
		ambientIntensity = ambientIntensityDay;
		Shader.SetGlobalFloat ("_Ambient", ambientIntensity);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.N)) {
			if (ambientIntensity >= ambientIntensityDay)
				ambientIntensity = ambientIntensityNight;
			else if (ambientIntensity <= ambientIntensityNight)
				ambientIntensity = ambientIntensityDay;

			Shader.SetGlobalFloat ("_Ambient", ambientIntensity);
			Debug.Log (Shader.GetGlobalFloat ("_Ambient"));
		}
	}
}