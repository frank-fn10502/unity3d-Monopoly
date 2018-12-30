using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scout
{   
    public Group group;
    public int totalStep;
    public List<List<Position>> pathList;
    public List<Position> choicePath;


    public Scout(Group group)
    {
        this.group = group;
        this.pathList = new List<List<Position>>();
    }

    public void reconnoiter(Map map ,int totalStep)
    {
        Debug.Log("totalStep " + totalStep);
        this.totalStep = totalStep;

        List<Position> path = new List<Position>();

        //找到所有路徑
        dfsSearch(group.EnterDirection 
                   ,map 
                   ,path
                   ,new Position(group.EnterDirection
                   ,group.CurrentBlockIndex
                   ,map.BlockList[group.CurrentBlockIndex]
                   ,map.BlockList[group.CurrentBlockIndex].Location)
                   ,0
                   ,totalStep + 1);
    }

    /*==========private==========*/
    private void dfsSearch(Direction enterDirection ,Map map ,List<Position> path ,Position position ,int next ,int step)
    {
        Position onePos = new Position(enterDirection
                                      ,position.blockIndex + next
                                      ,map.BlockList[position.blockIndex + next]
                                      ,map.BlockList[position.blockIndex + next].Location);

        path.Add(onePos);
        findNextBlock(map ,path ,path[path.Count - 1] ,--step);
        path.Remove(onePos);
    }
    private void findNextBlock(Map map ,List<Position> path ,Position position ,int step)
    {
        if ( step > 0 )
        {
            for ( int i = 0 ; i < position.block.DirectionList.Count ; i++ )
            {
                if ( position.block.DirectionList[i] != position.enterDirection )
                {
                    switch ( position.block.DirectionList[i] )
                    {
                        case Direction.East:
                            dfsSearch(Direction.West ,map ,path ,position ,1 ,step);
                            break;
                        case Direction.North:
                            dfsSearch(Direction.South ,map ,path ,position ,-30 ,step);
                            break;
                        case Direction.South:
                            dfsSearch(Direction.North ,map ,path ,position ,30 ,step);
                            break;
                        case Direction.West:
                            dfsSearch(Direction.East ,map ,path ,position ,-1 ,step);
                            break;
                    }
                }
            }
        }
        else
        {
            pathList.Add(new List<Position>(path));
        }
    }

    /*==========互動==========*/
    public void selectPath(int pathNo)//變換顏色 ,用以顯示選擇的道路
    {
        foreach ( Position oneDot in pathList[pathNo] )
        {
            oneDot.beSelected();
        }
    }
    public void checkOutPath(int pathNo)//確定這一條路
    {
        choicePath = new List<Position>(pathList[pathNo]);

        for ( int i = 0 ; i < pathList.Count ; i++ )
        {
            if ( i == pathNo ) continue;

            for ( int j = 0, k = 0 ; j < pathList[i].Count ; j++ )
            {
                if ( pathList[i][j].entity == pathList[pathNo][k].entity )
                {
                    k++;
                }
                else
                {
                    GameObject.Destroy(pathList[i][j].entity); //把不一樣的gameobject給刪除
                }
            }
        }

        //摧毀cs
        GameObject.Destroy(choicePath[choicePath.Count - 1].entity.GetComponent<PositionController>());
        pathList.Clear();

        group.State = PlayerState.Walking;//設定玩家狀態為"walking"
    }
    public void deleteDot(Position dot)//刪除走過的點
    {
        GameObject.Destroy(dot.entity);
        choicePath.Remove(dot);
    }
}