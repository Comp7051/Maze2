using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour
{
    GameObject[] walls;
    bool isActive;
    // Use this for initialization
    void Start()
    {
        isActive = true;
        walls = GameObject.FindGameObjectsWithTag("Wall");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Y)/* || Input.GetAxis(ZAxis) > 0*/)
        {
            isActive = !isActive;
            foreach(GameObject wall in walls){
                wall.GetComponent<MeshCollider>().enabled = isActive;
            }
        }
    }
}
