using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Console : MonoBehaviour
{
	// Main camera object
    private new Camera camera;
	// Text used for console
    public Text t;

    // Use this for initialization
    void Start()
    {
		// Grab the main camera for the scene
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
		//Track each key input
        foreach (char c in Input.inputString)
        {
            if (c == '\b') // has backspace/delete been pressed?
            {
                if (t.text.Length != 0)
                {
					// Remove character from text object
                    t.text = t.text.Substring(0, t.text.Length - 1);
                }
            }
            else if ((c == '\n') || (c == '\r')) // enter/return
            {
				// Carry out various commands depending on what the user typed in the text console
                if (t.text.Equals("red"))
                {
                    camera.backgroundColor = Color.red;
                }
                else if (t.text.Equals("green"))
                {
                    camera.backgroundColor = Color.green;
                }
                else if (t.text.Equals("blue"))
                {
                    camera.backgroundColor = Color.blue;
                }
                if (t.text.Equals("Give me points"))
                {
                    Score.player1Score++;
                }
                else if (t.text.Equals("Give ME! points"))
                {
                    Score.player2Score++;
                }
				// Clear the console
                t.text = "";
                print("User entered their name: " + t.text);
            }
			// Add typed character to text console
            else
            {
                t.text += c;
            }
        }
    }
}