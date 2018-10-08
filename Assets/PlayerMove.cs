using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Keycode for moving the paddle up
    public KeyCode forward;
    // Keycode for moving the paddle down
    public KeyCode backward;
    // Keycode for moving the paddle up
    public KeyCode right;
    // Keycode for moving the paddle down
    public KeyCode left;
    // What axis for moving the paddle up and down
    public string XAxis;

    public string ZAxis;

    public float thrust;
    public int speed;
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * -thrust);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookhere = new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
        Camera.main.transform.Rotate(lookhere);
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveForward = Input.GetAxis("Vertical");
        //taken from https://forum.unity.com/threads/moving-character-relative-to-camera.383086/
        //assuming we only using the single camera:
        var camera = Camera.main;

        //camera forward and right vectors:
        var forward = camera.transform.forward;
        var right = camera.transform.right;

        //project forward and right vectors on the horizontal plane (y = 0)
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        //this is the direction in the world space we want to move:
        var desiredMoveDirection = forward * moveForward + right * moveHorizontal;

        Vector3 movement = new Vector3(
            moveForward,
            0.0f,
            moveForward);

        rb.AddForce(desiredMoveDirection * thrust);
    }
}
