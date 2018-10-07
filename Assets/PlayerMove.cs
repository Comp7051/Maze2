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
        //// Get where the paddle object is
        //Vector3 position = gameObject.transform.position;
        //// Get the paddle's velocity
        //Vector3 velocity = GetComponent<Rigidbody>().velocity;

        ////Moving the paddle up, down or not at all depending on the input
        //if (Input.GetKey(backward)/* || Input.GetAxis(ZAxis) > 0*/)
        //{
        //    if (velocity.z < 10)
        //    {
        //        velocity.z += 10;
        //    }
        //}
        //else if (Input.GetKey(forward)/* || Input.GetAxis(ZAxis) < 0*/)
        //{
        //    if (velocity.z > -10)
        //    {
        //        velocity.z -= 10;
        //    }
        //}
        //else if (Input.GetKey(left)/* || Input.GetAxis(XAxis) < 0*/)
        //{
        //    if (velocity.x < 10)
        //    {
        //        velocity.x += 10;
        //    }
        //}
        //else if (Input.GetKey(right)/* || Input.GetAxis(XAxis) < 0*/)
        //{
        //    if (velocity.x > -10)
        //    {
        //        velocity.x -= 10;
        //    }
        //}
        //else
        //{
        //    velocity.x = 0;
        //    velocity.z = 0;
        //}
        //GetComponent<Rigidbody>().velocity = velocity;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(-moveHorizontal, 0.0f, -moveVertical);
        rb.AddForce(movement * thrust);
    }
}
