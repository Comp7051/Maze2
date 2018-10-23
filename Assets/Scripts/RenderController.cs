using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderController : MonoBehaviour {

	Renderer rend;
	float originalAmbientIntensity;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		//originalAmbientIntensity = rend.material.GetFloat ("Ambient Light Intensity");
		originalAmbientIntensity = Shader.GetGlobalFloat ("_AmbientLighIntensity");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.N)) {
			// Switch to Night mode.
			originalAmbientIntensity+=0.1f;
			Shader.SetGlobalFloat ("_AmbientLighIntensity", originalAmbientIntensity);
//			rend.material.SetFloat ("_AmbientLighIntensity", originalAmbientIntensity);
			Debug.Log(Shader.GetGlobalFloat ("_AmbientLighIntensity"));
		}

	}
}
