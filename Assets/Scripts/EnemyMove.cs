using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        //this is the direction in the world space we want to move:
        var desiredMoveDirection = new Vector3(0, 0, speed);

        //now we can apply the movement:
        transform.Translate(desiredMoveDirection);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Cell(Clone)")
        {
            speed *= -1;
            GameObject.Find("Root").transform.Rotate(new Vector3(0, 0, 180));
        }
    }
}
