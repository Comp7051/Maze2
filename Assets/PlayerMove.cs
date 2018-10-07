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
        transform.Rotate(lookhere);
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(-moveHorizontal, 0.0f, -moveVertical);
        rb.AddForce(movement * thrust);
    }
}
