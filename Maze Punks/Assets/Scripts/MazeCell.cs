using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    [SerializeField] GameObject leftWall, rightWall, frontWall, backWall, middleBlock;

    public bool isVisited { get; private set; }

    public void Visit()
    {
        isVisited = true;
        middleBlock.SetActive(false);
    }

    public void ClearLeftWall() { leftWall.SetActive(false); }
    public void ClearRightWall() { rightWall.SetActive(false); }
    public void ClearFrontWall() { frontWall.SetActive(false); }
    public void ClearBackWall() { backWall.SetActive(false); }
}
