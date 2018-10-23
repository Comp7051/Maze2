using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float thrust;
    private Rigidbody rb;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
	private SmoothMouseLook mouseLook;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * -thrust);
        initialPosition = gameObject.transform.position;
		mouseLook = GetComponent<SmoothMouseLook>();
    }

    // Update is called once per frame
    void Update()
    {
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

        if (Input.GetKeyUp(KeyCode.Home) || Input.GetKeyUp(KeyCode.Joystick1Button13))
        {
            gameObject.transform.position = initialPosition;
			mouseLook.ResetRotationToOriginal();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            gameObject.SetActive(false);
        }
    }
}
