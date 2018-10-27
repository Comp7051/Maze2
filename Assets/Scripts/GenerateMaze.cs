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
    private Vector3 enemyPosition;
    private GameObject player;
    private GameObject enemy;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        GenerateCells();
        CreateMaze();
    }

    private void CreateMaze()
    {
        list = new Stack<Cell>();

        x = Random.Range(0, width);
        y = Random.Range(0, height);

        player.transform.position = new Vector3(5 + 10 * x, 0, 5 + 10 * y);

        cells[x][y].isVisited = true;

        list.Push(cells[x][y]);

        while (list.Count > 0)
        {
            List<Cell> neighbours = new List<Cell>();

            if (x < width - 1)
            {
                if (!cells[x + 1][y].isVisited)
                {
                    neighbours.Add(cells[x + 1][y]);
                }
            }

            if (x > 0)
            {
                if (!cells[x - 1][y].isVisited)
                {
                    neighbours.Add(cells[x - 1][y]);
                }
            }

            if (y < height - 1)
            {
                if (!cells[x][y + 1].isVisited)
                {
                    neighbours.Add(cells[x][y + 1]);
                }
            }

            if (y > 0)
            {
                if (!cells[x][y - 1].isVisited)
                {
                    neighbours.Add(cells[x][y - 1]);
                }
            }
            if (neighbours.Count > 0)
            {
                Wall[] currentCellWalls = cells[x][y].Box.GetComponentsInChildren<Wall>();
                int nextCell = Random.Range(0, neighbours.Count);
                int nextx = neighbours[nextCell].posX;
                int nexty = neighbours[nextCell].posY;
                Wall[] nextCellWalls = cells[nextx][nexty].Box.GetComponentsInChildren<Wall>();

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
                enemyPosition = new Vector3(5 + 10 * x, 0, 5 + 10 * y);
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
            enemy.transform.position = enemyPosition;
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
