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
    private Stack<Cell> list;
    private List<List<Cell>> cells;

    // Use this for initialization
    void Start()
    {
        GenerateCells();

        CreateMaze();
    }

    private void CreateMaze()
    {
        list = new Stack<Cell>();
        x = Random.Range(0, width);
        y = Random.Range(0, height);
        cells[x][y].isVisited = true;
        list.Push(cells[x][y]);
        int count = 0;
        while (list.Count > 0 && count < 100)
        {
            Debug.Log("size " + list.Count);
            List<Cell> neighbours = new List<Cell>();

            Debug.Log("x " + x);
            Debug.Log("y " + y);
            if (x < width - 1)
            {
                Debug.Log(cells[x + 1][y].isVisited);
                if (!cells[x + 1][y].isVisited)
                {
                    Debug.Log("allah1");
                    neighbours.Add(cells[x + 1][y]);
                }
            }

            if (x > 0)
            {
                Debug.Log(cells[x - 1][y].isVisited);
                if (!cells[x - 1][y].isVisited)
                {
                    Debug.Log("allah2");
                    neighbours.Add(cells[x - 1][y]);
                }
            }

            if (y < height - 1)
            {
                Debug.Log(cells[x][y + 1].isVisited);
                if (!cells[x][y + 1].isVisited)
                {
                    Debug.Log("allah3");
                    neighbours.Add(cells[x][y + 1]);
                }
            }

            if (y > 0)
            {
                Debug.Log(cells[x][y - 1].isVisited);
                if (!cells[x][y - 1].isVisited)
                {
                    Debug.Log("allah4");
                    neighbours.Add(cells[x][y - 1]);
                }
            }

            Debug.Log("neighbours " + neighbours.Count);
            if (neighbours.Count > 0)
            {
                Wall[] currentCellWalls = cells[x][y].Box.GetComponentsInChildren<Wall>();
                int nextCell = Random.Range(0, neighbours.Count);
                int nextx = neighbours[nextCell].posX;
                int nexty = neighbours[nextCell].posY;
                Wall[] nextCellWalls = cells[nextx][nexty].Box.GetComponentsInChildren<Wall>();

                Debug.Log("current x " + x);
                Debug.Log("current y " + y);
                Debug.Log("next x " + nextx);
                Debug.Log("next y " + nexty);

                if (nextx > x)
                {
                    currentCellWalls[3].gameObject.GetComponent<MeshRenderer>().enabled = false;
                    currentCellWalls[3].gameObject.GetComponent<BoxCollider>().enabled = false;
                    nextCellWalls[1].gameObject.GetComponent<MeshRenderer>().enabled = false;
                    nextCellWalls[1].gameObject.GetComponent<BoxCollider>().enabled = false;
                }
                else if (nextx < x)
                {
                    currentCellWalls[1].gameObject.GetComponent<MeshRenderer>().enabled = false;
                    currentCellWalls[1].gameObject.GetComponent<BoxCollider>().enabled = false;
                    nextCellWalls[3].gameObject.GetComponent<MeshRenderer>().enabled = false;
                    nextCellWalls[3].gameObject.GetComponent<BoxCollider>().enabled = false;
                }

                if (nexty > y)
                {
                    currentCellWalls[2].gameObject.GetComponent<MeshRenderer>().enabled = false;
                    currentCellWalls[2].gameObject.GetComponent<BoxCollider>().enabled = false;
                    nextCellWalls[0].gameObject.GetComponent<MeshRenderer>().enabled = false;
                    nextCellWalls[0].gameObject.GetComponent<BoxCollider>().enabled = false;
                }
                else if (nexty < y)
                {
                    currentCellWalls[0].gameObject.GetComponent<MeshRenderer>().enabled = false;
                    currentCellWalls[0].gameObject.GetComponent<BoxCollider>().enabled = false;
                    nextCellWalls[2].gameObject.GetComponent<MeshRenderer>().enabled = false;
                    nextCellWalls[2].gameObject.GetComponent<BoxCollider>().enabled = false;
                }

                x = nextx;
                y = nexty;
                cells[x][y].isVisited = true;
                list.Push(cells[x][y]);
            }
            else if (neighbours.Count <= 0)
            {
                list.Pop();
                if (list.Count > 0)
                {
                    x = list.Peek().posX;
                    y = list.Peek().posY;
                }
            }
            count++;
        }
    }

    private void GenerateCells()
    {
        cells = new List<List<Cell>>();
        for (int i = 0; i < width; i++)
        {
            List<Cell> row = new List<Cell>();
            for (int j = 0; j < width; j++)
            {
                GameObject gameObject = Instantiate(Resources.Load("Cell")) as GameObject;
                gameObject.transform.position = new Vector3(5 + 10 * i, 0, 5 + 10 * j);
                Cell cell = new Cell(gameObject, i, j);
                row.Add(cell);
            }
            cells.Add(row);
        }
    }
}
