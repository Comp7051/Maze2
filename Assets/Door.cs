using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    RaycastHit hit;

    // Use this for initialization
    void Start()
    {
        GetComponent<Animator>().speed = 0;
        hit = new RaycastHit();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, -transform.up, out hit, 9))
        {
            if (hit.collider.gameObject.name == "Player") {
                Debug.DrawRay(transform.position, -transform.up * 9f, Color.red);
                if (Input.GetMouseButtonDown(1))
                {
                    GetComponent<Animator>().speed = 1;
                }
            }
        }
        else
        {
            Debug.DrawRay(transform.position, -transform.up * 9f, Color.green);
        }


    }
}
