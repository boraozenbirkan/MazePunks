using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] MazeCell cellPrefab;
    [SerializeField] int mazeLenght, mazeHeight;

    MazeCell[,] mazeGrid;
    
    void Start()
    {
        mazeGrid = new MazeCell[mazeLenght, mazeHeight];

        for (int x = 0; x < mazeLenght; x++)
        {
            for (int y = 0; y < mazeHeight; y++)
            {
                MazeCell newCell = Instantiate(cellPrefab, new Vector3(x, y, 0), Quaternion.identity);
                newCell.transform.SetParent(transform);
                mazeGrid[x, y] = newCell;
            }
        }

        GenerateMaze(null, mazeGrid[0, 0]);
    }

    void GenerateMaze(MazeCell previousCell, MazeCell currenCell)
    {
        currenCell.Visit();
        ClearWalls(previousCell, currenCell);

        MazeCell nextCell;
        
        do 
        {
            nextCell = GetNextUnvisitedCell(currenCell);

            if (nextCell != null)
            {
                GenerateMaze(currenCell, nextCell);
            }
        } 
        while (nextCell != null);
    }

    MazeCell GetNextUnvisitedCell(MazeCell currentCell)
    {
        var unVisitedCells = GetUnvisitedCells(currentCell);

        return unVisitedCells.OrderBy(_ => Random.Range(1, 10)).FirstOrDefault();
    }

    IEnumerable<MazeCell> GetUnvisitedCells(MazeCell currentCell)
    {
        int x = (int)currentCell.transform.position.x;
        int y = (int)currentCell.transform.position.y;

        if (x + 1 < mazeLenght)
        {
            var cellToRight = mazeGrid[x + 1, y];

            if (!cellToRight.isVisited) { yield return cellToRight; }
        }

        if (x - 1 >= 0)
        {
            var cellToLeft = mazeGrid[x - 1, y];

            if (!cellToLeft.isVisited) { yield return cellToLeft; }
        }

        if (y + 1 < mazeHeight)
        {
            var cellToFront = mazeGrid[x, y + 1];

            if (!cellToFront.isVisited) { yield return cellToFront; }
        }

        if (y - 1 >= 0)
        {
            var cellToBack = mazeGrid[x, y - 1];

            if (!cellToBack.isVisited) { yield return cellToBack; }
        }
    }

    void ClearWalls(MazeCell previousCell, MazeCell currentCell)
    {
        if (previousCell == null) return;

        if (previousCell.transform.position.x < currentCell.transform.position.x)
        {
            previousCell.ClearRightWall();
            currentCell.ClearLeftWall();
            return;
        }

        if (previousCell.transform.position.x > currentCell.transform.position.x)
        {
            previousCell.ClearLeftWall();
            currentCell.ClearRightWall();
            return;
        }

        if (previousCell.transform.position.y < currentCell.transform.position.y)
        {
            previousCell.ClearFrontWall();
            currentCell.ClearBackWall();
            return;
        }

        if (previousCell.transform.position.y > currentCell.transform.position.y)
        {
            previousCell.ClearBackWall();
            currentCell.ClearFrontWall();
            return;
        }
    }

}
