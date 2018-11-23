using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPaddle : MonoBehaviour {
	// The pong ball
    GameObject ball;
    // enabled and disable AI movement
    public bool isEnabled;

    // Use this for initialization
    void Start () {
		// Grab the pong sphere
        ball = GameObject.Find("Sphere");
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Joystick1Button0)) && gameObject.name == "Paddle1")
        {
            isEnabled = false;
        }
        else if ((Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Joystick1Button1)) && gameObject.name == "Paddle1")
        {
            isEnabled = true;
        }
        else if ((Input.GetKey(KeyCode.Alpha3) || Input.GetKey(KeyCode.Joystick1Button2)) && gameObject.name == "Paddle2")
        {
            isEnabled = false;
        }
        else if ((Input.GetKey(KeyCode.Alpha4) || Input.GetKey(KeyCode.Joystick1Button3)) && gameObject.name == "Paddle2")
        {
            isEnabled = true;
        }

        if (isEnabled)
        {
            // Get where the paddle object is
            Vector3 position = gameObject.transform.position;
            // Get the paddle's velocity
            Vector3 velocity = GetComponent<Rigidbody>().velocity;

            // Continuously move the paddle so that it's y position matches the ball
            if (ball.transform.position.y > gameObject.transform.position.y)
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
}
