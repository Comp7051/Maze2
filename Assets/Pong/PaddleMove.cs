using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMove : MonoBehaviour
{
    // Keycode for moving the paddle up
    public KeyCode paddleUp;
    // Keycode for moving the paddle down
    public KeyCode paddleDown;
    // What axis for moving the paddle up and down
    public string axis;
    // enabled and disable manual movement
    public bool isEnabled;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Joystick1Button0)) && gameObject.name == "Paddle1")
        {
            isEnabled = true;
        }
        else if ((Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Joystick1Button1)) && gameObject.name == "Paddle1")
        {
            isEnabled = false;
        }
        else if ((Input.GetKey(KeyCode.Alpha3) || Input.GetKey(KeyCode.Joystick1Button2)) && gameObject.name == "Paddle2")
        {
            isEnabled = true;
        }
        else if ((Input.GetKey(KeyCode.Alpha4) || Input.GetKey(KeyCode.Joystick1Button3)) && gameObject.name == "Paddle2")
        {
            isEnabled = false;
        }

        if (isEnabled)
        {
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
}
