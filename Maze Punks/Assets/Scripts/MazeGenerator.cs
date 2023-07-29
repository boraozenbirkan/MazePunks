using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MazeGenerator : MonoBehaviourPunCallbacks
{
    [SerializeField] MazeCell cellPrefab;
    [SerializeField] Transform mazeTransform;
    [SerializeField] int mazeLenght, mazeHeight;
    [SerializeField] GameObject[] mazeArray;
    [SerializeField] GameObject reward;

    MazeCell[,] mazeGrid;
    int mazeNumber = 0;

    PhotonView photonView;
    GameObject objToSpawn;

    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }

    void Start()
    {
        /*  Maze Generation code. NOT USING FOR THIS DEMO !!!
         * 
        mazeGrid = new MazeCell[mazeLenght, mazeHeight];

        for (int x = 0; x < mazeLenght; x++)
        {
            for (int y = 0; y < mazeHeight; y++)
            {
                MazeCell newCell = Instantiate(cellPrefab, new Vector3(x, y, 0), Quaternion.identity);
                newCell.transform.SetParent(mazeTransform);
                mazeGrid[x, y] = newCell;
            }
        }

        GenerateMaze(null, mazeGrid[0, 0]);
        */
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

    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            mazeNumber = Random.Range(0, mazeArray.Length);

            mazeArray[mazeNumber].SetActive(true);
            reward.SetActive(true);
        }
    }

    public void CloseMaze()
    {
        mazeArray[mazeNumber].SetActive(false);
        reward.SetActive(false);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.LogError("A player connected!");
        // When a player connects, master shares the maze with them.
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.LogError("I'm the master, sharing the maze number: " + mazeNumber);
            photonView.RPC("ShareMaze", RpcTarget.Others, mazeNumber);
        }
    }

    [PunRPC]
    public void ShareMaze(int mazeNumber)
    {
        Debug.LogError("I got the maze! Maze Number: " + mazeNumber);
        this.mazeNumber = mazeNumber;
        mazeArray[mazeNumber].SetActive(true);
        reward.SetActive(true);
    }
}
