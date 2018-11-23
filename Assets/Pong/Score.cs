using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

	//Canvas which contains the console text
    GameObject console;
	//Score for player 1
    public static int player1Score = 0;
	//Score for player 2
    public static int player2Score = 0;
	
    // Use this for initialization
    void Start () {
		// Grab the canvas object and...
        console = GameObject.Find("Canvas");
		// ...set it to inactive
        console.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		// Activate the console by pressing c
        if (Input.GetKeyUp(KeyCode.C))
        {
            console.SetActive(true);
        }
		// Deactivate the console by pressing escape
        else if (Input.GetKeyUp(KeyCode.Escape))
        {
            console.SetActive(false);
        }
    }

    private void OnGUI()
    {
		// Update the GUI labels with new score
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), player1Score.ToString());
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), player2Score.ToString());

		// Reset scores to zero after game is over
        if (player1Score== 11)
        {
            player1Score = 0;
            player2Score = 0;

        }
        else if (player2Score == 11)
        {
            player1Score = 0;
            player2Score = 0;
        }
    }
}
