using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float thrust;
    private Rigidbody rb;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * -thrust);
        initialPosition = gameObject.transform.position;
        initialRotation = Camera.main.transform.rotation;
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

        rb.AddForce(desiredMoveDirection * thrust);

        if (Input.GetKeyUp(KeyCode.Home) || Input.GetButton("joystick button 13"))
        {
            gameObject.transform.position = initialPosition;
            Camera.main.transform.rotation = initialRotation;
        }
    }
}
