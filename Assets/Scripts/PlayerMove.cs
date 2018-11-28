using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float thrust;
    private Rigidbody rb;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
	private SmoothMouseLook mouseLook;
    private GameObject winScreen;
    private GameObject loseScreen;
	public AudioSource wallBump;

	private GameObject enemy;

    // Use this for initialization
    void Start()
    {
        winScreen = GameObject.Find("WinScreen");
        winScreen.SetActive(false);
        loseScreen = GameObject.Find("LoseScreen");
        loseScreen.SetActive(false);
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * -thrust);
        initialPosition = gameObject.transform.position;
		initialRotation = gameObject.transform.rotation;
		mouseLook = GetComponent<SmoothMouseLook>();

		enemy = GameObject.FindGameObjectWithTag ("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyUp (KeyCode.F1) || Input.GetKeyUp(KeyCode.JoystickButton1)) {
			SaveGame();
		}
		if (Input.GetKeyUp (KeyCode.F2) || Input.GetKeyUp(KeyCode.JoystickButton7) ) {
			LoadGame();
		}
    }

	void SaveGame() {

		PlayerPrefs.SetFloat(CombineKeys("player", "position", "x"), gameObject.transform.position.x);
		PlayerPrefs.SetFloat(CombineKeys("player", "position", "y"), gameObject.transform.position.y);
		PlayerPrefs.SetFloat(CombineKeys("player", "position", "z"), gameObject.transform.position.z);

		PlayerPrefs.SetFloat(CombineKeys("player", "rotation", "x"), gameObject.transform.rotation.x);
		PlayerPrefs.SetFloat(CombineKeys("player", "rotation", "y"), gameObject.transform.rotation.y);
		PlayerPrefs.SetFloat(CombineKeys("player", "rotation", "z"), gameObject.transform.rotation.z);
		PlayerPrefs.SetFloat(CombineKeys("player", "rotation", "w"), gameObject.transform.rotation.w);

		PlayerPrefs.SetInt(CombineKeys("player", "score", ""), ScoreManager.score);

		PlayerPrefs.SetFloat(CombineKeys("enemy", "position", "x"), enemy.transform.position.x);
		PlayerPrefs.SetFloat(CombineKeys("enemy", "position", "y"), enemy.transform.position.y);
		PlayerPrefs.SetFloat(CombineKeys("enemy", "position", "z"), enemy.transform.position.z);

		PlayerPrefs.SetFloat(CombineKeys("enemy", "rotation", "x"), enemy.transform.rotation.x);
		PlayerPrefs.SetFloat(CombineKeys("enemy", "rotation", "y"), enemy.transform.rotation.y);
		PlayerPrefs.SetFloat(CombineKeys("enemy", "rotation", "z"), enemy.transform.rotation.z);
		PlayerPrefs.SetFloat(CombineKeys("enemy", "rotation", "w"), enemy.transform.rotation.w);
	}

	void LoadGame() {

		Vector3 position;
		position.x = SG_GetFloat (CombineKeys("player", "position", "x"), initialPosition.x);
		position.y = SG_GetFloat (CombineKeys("player", "position", "y"), initialPosition.y);
		position.z = SG_GetFloat (CombineKeys("player", "position", "z"), initialPosition.z);

		Quaternion rotation;
		rotation.x = SG_GetFloat (CombineKeys("player", "rotation", "x"), initialRotation.x);
		rotation.y = SG_GetFloat (CombineKeys("player", "rotation", "y"), initialRotation.y);
		rotation.z = SG_GetFloat (CombineKeys("player", "rotation", "z"), initialRotation.z);
		rotation.w = SG_GetFloat (CombineKeys("player", "rotation", "w"), initialRotation.w);

		gameObject.transform.SetPositionAndRotation (position, rotation);

		ScoreManager.score = SG_GetInt (CombineKeys ("player", "score", ""), 0);

		Vector3 enemyPosition;
		enemyPosition.x = SG_GetFloat (CombineKeys("enemy", "position", "x"), initialPosition.x);
		enemyPosition.y = SG_GetFloat (CombineKeys("enemy", "position", "y"), initialPosition.y);
		enemyPosition.z = SG_GetFloat (CombineKeys("enemy", "position", "z"), initialPosition.z);

		Quaternion enemyRotation;
		enemyRotation.x = SG_GetFloat (CombineKeys("enemy", "rotation", "x"), initialRotation.x);
		enemyRotation.y = SG_GetFloat (CombineKeys("enemy", "rotation", "y"), initialRotation.y);
		enemyRotation.z = SG_GetFloat (CombineKeys("enemy", "rotation", "z"), initialRotation.z);
		enemyRotation.w = SG_GetFloat (CombineKeys("enemy", "rotation", "w"), initialRotation.w);

		enemy.transform.SetPositionAndRotation (enemyPosition, enemyRotation);
	}

	// Just to consistently build keys from subkeys. One of these is required, the rest can be blank
	string CombineKeys(string keyGroup, string key, string subKey)
	{
		return keyGroup + key + subKey;
	}

	float SG_GetFloat(string key, float defaultValue) {
		if (PlayerPrefs.HasKey (key)) {
			return PlayerPrefs.GetFloat (key);
		} else {
			return defaultValue;
		}
	}

	int SG_GetInt(string key, int defaultValue) {
		if (PlayerPrefs.HasKey (key)) {
			return PlayerPrefs.GetInt (key);
		} else {
			return defaultValue;
		}
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
		if (collision.gameObject.tag == "Enemy") {
			Time.timeScale = 0;
			loseScreen.SetActive (true);
		} else if (collision.gameObject.tag == "Win") {
			Time.timeScale = 0;
			winScreen.SetActive (true);
		} else if (collision.gameObject.tag == "Wall") {
			wallBump.Play ();
		}
    }
    
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
