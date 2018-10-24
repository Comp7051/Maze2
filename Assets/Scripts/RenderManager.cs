using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderManager : MonoBehaviour {

	private float ambientIntensity;

	// Use this for initialization
	void Start () {
		ambientIntensity = 0.0f;
		Shader.SetGlobalFloat ("_Ambient", ambientIntensity);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.N)) {
			if (ambientIntensity >= 1.0f)
				ambientIntensity = 0.0f;
			else if (ambientIntensity <= 0.0f)
				ambientIntensity = 1.0f;
			
			Shader.SetGlobalFloat ("_Ambient", ambientIntensity);
			Debug.Log (Shader.GetGlobalFloat ("_Ambient"));
		}
	}

	private Material fogGradientMaterial;

	void OnValidate ()
	{
		fogGradientMaterial = new Material( Shader.Find("Custom/FogEffect") );
	}

	void OnRenderImage (RenderTexture source, RenderTexture destination)
	{
		Graphics.Blit (source, destination, fogGradientMaterial);
	}
}
