using UnityEngine;
using System.Collections;

public class Cell
{
    public bool isVisited { get; set; }

    public GameObject Box { get; set; }

    public int posX;

    public int posY;

    public Cell(GameObject gameObject, int x, int y)
    {
        Box = gameObject;
        isVisited = false;
        posX = x;
        posY = y;
    }
}
