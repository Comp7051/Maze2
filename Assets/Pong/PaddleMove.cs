using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMove : MonoBehaviour {
	// Keycode for moving the paddle up
    public KeyCode paddleUp;
    // Keycode for moving the paddle down
	public KeyCode paddleDown;
    // What axis for moving the paddle up and down
	public string axis;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Get where the paddle object is
        Vector3 position = gameObject.transform.position;
        // Get the paddle's velocity
		Vector3 velocity = GetComponent<Rigidbody>().velocity;

		//Moving the paddle up, down or not at all depending on the input
        if (Input.GetKey(paddleUp) || Input.GetAxis(axis) > 0)
        {
            if (position.y < 5 && velocity.y < 10)
            {
                velocity.y += 10;
            }
        }
        else if (Input.GetKey(paddleDown) || Input.GetAxis(axis) < 0)
        {
            if (position.y > -5 && velocity.y > -10)
            {
                velocity.y -= 10;
            }
        }
        else
        {
            velocity.y = 0;
        }
        GetComponent<Rigidbody>().velocity = velocity;
    }
}
