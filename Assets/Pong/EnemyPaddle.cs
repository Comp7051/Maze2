using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPaddle : MonoBehaviour {
	// The pong ball
    GameObject ball;

	// Use this for initialization
	void Start () {
		// Grab the pong sphere
        ball = GameObject.Find("Sphere");
    }
	
	// Update is called once per frame
	void Update () {
		// Get where the paddle object is
        Vector3 position = gameObject.transform.position;
        // Get the paddle's velocity
		Vector3 velocity = GetComponent<Rigidbody>().velocity;

		// Continuously move the paddle so that it's y position matches the ball
        if (ball.transform.position.y> gameObject.transform.position.y)
        {
            if (position.y < 5 && velocity.y < 2.5)
            {
				// Limit movement to 1/4 the speed of the player
                velocity.y += 2.5f;
            }
        }
        else if (ball.transform.position.y < gameObject.transform.position.y)
        {
            if (position.y > -5 && velocity.y > -2.5)
            {
                velocity.y -= 2.5f;
            }
        }
        else
        {
            velocity.y = 0;
        }
        GetComponent<Rigidbody>().velocity = velocity;
    }
}
