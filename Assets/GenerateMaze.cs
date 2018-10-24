using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMaze : MonoBehaviour
{

    public int width;
    public int height;
    private int[,] maze;
    private int x;
    private int y;
    private int[] list;

    // Use this for initialization
    void Start()
    {
        x = Random.Range(0, width);
        y = Random.Range(0, height);

        maze = new int[width, height];

        GenerateCells();
    }

    private void GenerateCells()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < width; j++)
            {
                GameObject cell = Instantiate(Resources.Load("Cell")) as GameObject;
                cell.transform.position = new Vector3(5 + 10 * i, 0, 5 + 10 * j);
            }
        }
    }
}
