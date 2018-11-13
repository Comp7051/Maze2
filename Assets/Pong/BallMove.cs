using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
	// Velocity of the ball
    public static Vector3 velocity;
	// Text object displayed if player 1 wins
    private GameObject player1Wins;
	// Text object displayed if player 2 wins
    private GameObject player2Wins;

    // Use this for initialization
    void Start()
    {
		// Grab the text boxes
        player1Wins = GameObject.Find("Player1Wins");
        player2Wins = GameObject.Find("Player2Wins");
		// Set them to inactive
        player1Wins.SetActive(false);
        player2Wins.SetActive(false);
		// The ball's velocity and...
        velocity = GetComponent<Rigidbody>().velocity;
		// ... set it to -10 (going towards player 1)
        velocity.x = -10;
    }

    // Update is called once per frame
    void Update()
    {
		// Set the sphere's velocity
        GetComponent<Rigidbody>().velocity = velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
		// Grab position of the ball
        Vector3 position = gameObject.transform.position;

		// If ball collides with a paddle
        if (collision.collider.CompareTag("Player"))
        {
            velocity.x = -velocity.x;
            velocity.y = velocity.y / 2 + collision.collider.attachedRigidbody.velocity.y / 3;
        }
		// If ball collides with the left wall
        else if (collision.gameObject.name == "LeftWall")
        {
            // Increase player 2's score
            Score.player2Score++;
            // Place the sphere back in the middle of the play area
            gameObject.transform.position = Vector3.zero;
            // If player 2 has hit 11 points
            if (Score.player2Score == 11)
            {
                // Show the player 2 win text
                player2Wins.SetActive(true);
                StartCoroutine(Win());
            }
            else
            {
                // Send the ball towards player 2
                velocity.x = 10;
            }
        }
		// If ball collides with the right wall
        else if (collision.gameObject.name == "RightWall")
        {
            // Increase player 1's score
            Score.player1Score++;
            // Place the sphere back in the middle of the play area
            gameObject.transform.position = Vector3.zero;
            // If player 1 has hit 11 points
            if (Score.player1Score == 11)
            {
                // Show the player 2 win text
                player1Wins.SetActive(true);
                StartCoroutine(Win());
            }
            else
            {
                // Send the ball towards player 1
                velocity.x = -10;
            }
        }
        // If ball collides with the top or bottom wall
        else if (collision.gameObject.name == "TopWall" || collision.gameObject.name == "BottomWall")
        {
            velocity.y = -velocity.y;
        }
    }

    IEnumerator Win()
    {
        // Set the ball's velocity to 0
        velocity.x = 0;
        velocity.y = 0;
        // Wait 3 seconds
        yield return new WaitForSeconds(3);
        // Hide the player win texts
        player1Wins.SetActive(false);
        player2Wins.SetActive(false);
        // Send ball towards player 1
        velocity.x = -10;
    }
}
