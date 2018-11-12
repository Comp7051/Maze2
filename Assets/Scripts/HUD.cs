using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	public Text score;

	// Use this for initialization
	void Start () {
		score.text = "Score:";
	}
	
	// Update is called once per frame
	void Update () {
		score.text = "Score: " + ScoreManager.GetScore ().ToString();
	}
}
