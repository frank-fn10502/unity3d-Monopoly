using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scout
{
    private List<List<Position>> pathList;

    public Group group;
    public int totalStep;
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
        setTempPath(group.EnterDirection ,map ,path 
                   ,new Position(group.EnterDirection 
                   ,group.CurrentBlockIndex
                   ,map.BlockEntityList[group.CurrentBlockIndex].Block
                   ,map.BlockEntityList[group.CurrentBlockIndex].Block.Location)
                   ,0
                   ,totalStep + 1);
        
        //dfsSearch(map
        //         ,path
        //         ,new Position(group.CurrentBlockIndex
        //         ,map.BlockEntityList[group.CurrentBlockIndex].Block
        //         ,map.BlockEntityList[group.CurrentBlockIndex].Block.Location)
        //         ,totalStep);

        createSelect();        
    }
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

        for(int i = 0 ; i < pathList.Count ; i++ )
        {
            if ( i == pathNo ) continue;

            for(int j = 0 ,k = 0; j < pathList[i].Count ; j++ )
            {
                if( pathList[i][j].entity == pathList[pathNo][k].entity)
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
        GameObject.Destroy(choicePath[choicePath.Count - 1].entity.GetComponent<UnityPath>());
        pathList.Clear();
        group.State = PlayerState.Walking;//設定玩家狀態為"walking"
    }
    public void deleteDot(Position dot)//刪除走過的點
    {        
        GameObject.Destroy(dot.entity);
        choicePath.Remove(dot);
    }


    private void createSelect()
    {
        int i = 0;
        foreach ( List<Position> onePath in pathList )
        {
            GameObject entity = onePath[onePath.Count - 1].entity;

            entity.AddComponent<UnityPath>();
            entity.GetComponent<UnityPath>().pathNo = i;
            entity.GetComponent<UnityPath>().scout = this;
            entity.transform.localScale = new Vector3(1.5f ,0.1f ,1.5f);
            i++;
        }
        if(pathList.Count == 1)
        {
            //checkOutPath(0);
        }
    }
    private void dfsSearch(Map map ,List<Position> path ,Position position ,int step)
    {
        if ( step > 0 )
        {
            for ( int i = 0 ; i < position.block.DirectionList.Count ; i++ )
            {
                if( position.block.DirectionList[i] != position.enterDirection)
                {
                    switch ( position.block.DirectionList[i] )
                    {
                        case Direction.East:
                            setTempPath(Direction.West ,map ,path ,position ,30 ,step);
                            break;
                        case Direction.North:
                            setTempPath(Direction.South ,map ,path ,position ,1 ,step);
                            break;
                        case Direction.South:
                            setTempPath(Direction.North ,map ,path ,position ,-1 ,step);
                            break;
                        case Direction.West:
                            setTempPath(Direction.East ,map ,path ,position ,-30 ,step);
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
    private void setTempPath(Direction enterDirection , Map map ,List<Position> path ,Position position ,int next ,int step)
    {
        Position tempPos = new Position(enterDirection 
                                       ,position.blockIndex + next
                                       ,map.BlockEntityList[position.blockIndex + next].Block
                                       ,map.BlockEntityList[position.blockIndex + next].Block.Location);
        tempPos.buildEntity();
        path.Add(tempPos);
        dfsSearch(map ,path ,path[path.Count - 1] ,--step);
        path.Remove(tempPos);
    }
}