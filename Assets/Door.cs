using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.up);
        if (Physics.Raycast(transform.position, fwd, 10))
        {
            Debug.DrawRay(transform.position, -transform.up * 10f, Color.red);
            print("There is something in front of the object!");
        }
        else
        {
            Debug.DrawRay(transform.position, -transform.up * 10f, Color.green);
            print("There is nothing in front of the object.");
        }
    }
}
