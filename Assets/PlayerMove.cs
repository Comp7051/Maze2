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
        float moveForward = -Input.GetAxis("Vertical");
        float rotation = Camera.main.transform.rotation.eulerAngles.y - 90;
        if (rotation >= 2 * 360)
        {
            rotation -= (360);
        }
        Debug.Log("rotation " + rotation);
        Debug.Log(Mathf.Cos(rotation));
        Debug.Log(Mathf.Sin(rotation));
        Vector3 movement = new Vector3(
            moveForward * -Mathf.Cos(rotation * Mathf.Deg2Rad),
            0.0f,
            moveForward * Mathf.Sin(rotation * Mathf.Deg2Rad));
        Debug.Log("movement " + movement);
        rb.AddForce(movement * thrust);
    }
}
