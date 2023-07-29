using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    [SerializeField] GameObject leftWall, rightWall, frontWall, backWall, middleBlock;

    public bool isVisited { get; private set; }
    public bool isLeftDown { get; private set; }
    public bool isRightDown { get; private set; }
    public bool isFrontDown { get; private set; }
    public bool isBackDown { get; private set; }

    public void Visit()
    {
        isVisited = true;
        middleBlock.SetActive(false);
    }

    public void ClearLeftWall() { leftWall.SetActive(false); isLeftDown = true; }
    public void ClearRightWall() { rightWall.SetActive(false); isRightDown = true; }
    public void ClearFrontWall() { frontWall.SetActive(false); isFrontDown = true; }
    public void ClearBackWall() { backWall.SetActive(false); isBackDown = true; }
}
