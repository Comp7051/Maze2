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
    private List<GameObject> list;
    private List<List<GameObject>> cells;

    // Use this for initialization
    void Start()
    {

        GenerateCells();

        CreateMaze();
    }

    private void CreateMaze()
    {
        int[] validChoices = { 1, -1 };

        x = Random.Range(0, width);
        y = Random.Range(0, height);
        list.Add(cells[x][y]);

        while (list.Count > 0)
        {
            int nextCell = validChoices[Random.Range(0, 1)];
            list.Add(cells[x][y]);


        }
    }

    private void GenerateCells()
    {
        cells = new List<List<GameObject>>();
        for (int i = 0; i < width; i++)
        {
            List<GameObject> row = new List<GameObject>();
            for (int j = 0; j < width; j++)
            {
                GameObject cell = Instantiate(Resources.Load("Cell")) as GameObject;
                cell.transform.position = new Vector3(5 + 10 * i, 0, 5 + 10 * j);
                row.Add(cell);
            }
            cells.Add(row);
        }
    }
}
