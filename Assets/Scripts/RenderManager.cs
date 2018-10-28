using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderManager : MonoBehaviour {

	private float ambientIntensity;
	public float ambientIntensityDay;
	public float ambientIntensityNight;

	public Material fogmat;
	Camera playerCamera;

	// Use this for initialization
	void Start () {
		ambientIntensity = ambientIntensityDay;
		Shader.SetGlobalFloat ("_Ambient", ambientIntensity);
		playerCamera = Camera.main;
		playerCamera.depthTextureMode = DepthTextureMode.Depth;
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

	void OnRenderImage (RenderTexture source, RenderTexture destination){
		Graphics.Blit(source, destination, fogmat);
		//mat is the material which contains the shader
		//we are passing the destination RenderTexture to
	}
}