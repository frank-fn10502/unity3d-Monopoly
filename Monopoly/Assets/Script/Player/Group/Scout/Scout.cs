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
                              ,group.Location)
                 ,0
                 ,totalStep + 1);

        foreach(List<Position> p in pathList)
        {
            p.RemoveAt(p.Count - 1);
            if(p[0].block is BuildingBlock )
            {
                BuildingBlock buildingBlock = (BuildingBlock)p[0].block;
                if(buildingBlock.PathLocations.Count > 1)
                {
                    Vector3 realSecondP = p[1].block.standPoint(p[2].location);
                    if ( p[1].location != realSecondP )
                    {
                        Vector3 v = p[0].location;
                        p[0].location = p[1].location;
                        p[1].location = v;
                    }
                }
            }

            if ( p[1].location == group.Location )
            {
                p.RemoveAt(0);
                //p[0] = null;
            }
        }
    }

    /*==========private==========*/
    private void dfsSearch(Direction enterDirection ,Map map ,List<Position> path ,Position position ,int next ,int step)
    {
        //Position onePos = new Position(enterDirection
        //                              ,position.blockIndex + next
        //                              ,map.BlockList[position.blockIndex + next]
        //                              ,map.BlockList[position.blockIndex + next].standPoint(position.location));
        //path.Add(onePos);
        //findNextBlock(map ,path ,path[path.Count - 1] ,--step);
        //path.Remove(onePos);

        List<Position> positions = new List<Position>();
        Vector3 loc;
        for (int i = 0 ; i < 2 ; i++ )
        {
            loc = (i == 0) ? position.location : positions[0].location;

            Position onePos = new Position(enterDirection
                                      ,position.blockIndex + next
                                      ,map.BlockList[position.blockIndex + next]
                                      ,map.BlockList[position.blockIndex + next].standPoint(loc));

            if(positions.Count > 1)
            {
                if(positions[0].location == onePos.location)
                {
                    break;
                }
            }
            else
            {
                positions.Add(onePos);
            }           
        }
        path.AddRange(positions);
        findNextBlock(map ,path ,path[path.Count - 1] ,--step);
        foreach(Position p in positions)
        {
            path.Remove(p);
        }        
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
            //sortPath(path);//先整理
            pathList.Add(new List<Position>(path));
        }
    }
    private bool sameDot(Position currentP ,List<Position> choiceP)
    {
        foreach ( Position p in choiceP )
        {
            if ( currentP.entity.Equals(p.entity) ) return true;
        }
        return false;
    }

    /*==========互動==========*/
    public void leavePath(int pathNo)//變換顏色 ,用以顯示選擇的道路
    {
        foreach ( Position oneDot in pathList[pathNo] )
        {
            oneDot.leave();
        }
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

        for ( int i = 0 ; i < pathList.Count ; i++ )
        {
            if ( i == pathNo ) continue;

            for ( int j = 0 ; j < pathList[i].Count ; j++ )
            {
                //if ( pathList[i][j].entity == pathList[pathNo][k].entity )
                if ( sameDot(pathList[i][j] ,choicePath) )
                {
                    if ( j == pathList[i].Count - 1 &&
                        pathList[i][j].entity != pathList[pathNo][pathList[pathNo].Count - 1].entity )
                    {
                        GameObject.Destroy(pathList[i][j].entity.GetComponent<PositionController>());
                        pathList[i][j].entity.transform.localScale = new Vector3(0.8f ,0.1f ,0.8f);
                    }
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

        //if ( choicePath[1].location == group.Location )
        //{
        //    choicePath.RemoveAt(0);
        //}

        group.State = PlayerState.Walking;//設定玩家狀態為"walking"
    }
    public void deleteDot(Position dot)//刪除走過的點
    {
        choicePath.Remove(dot);
        //Position removeDot = dot;
        if ( !sameDot(dot ,choicePath) )
        {
            GameObject.Destroy(dot.entity);
        }
    }

    /*==========private==========*/
    //private List<Position> addPosition(Direction enterDirection ,Map map ,List<Position> path ,Position position ,Direction outDirection)
    //{
    //    List<Position> positions = new List<Position>();
    //    foreach ( Vector3 loc in map.BlockList[position.blockIndex].standPoint(/*out*/) )
    //    {
    //        Position onePos = new Position(enterDirection
    //                                      ,position.blockIndex
    //                                      ,map.BlockList[position.blockIndex]
    //                                      ,loc);
    //        positions.Add(onePos);
    //    }
    //    path.AddRange(positions);
    //    return positions;
    //}
    //private void sortPath(List<Position> path)
    //{
    //    bool zSort = false ,xSort = false;
    //    Position[] selects = new Position[3];
    //    Vector3 offset1 ,offset2;

    //    for(int i = 2 ; i <= path.Count ; i+=2 )/////?
    //    {
    //        if( i < path.Count )
    //        {
    //            selects[0] = path[i - 2];
    //            selects[1] = path[i - 1];
    //            selects[2] = path[i];
    //            offset1 = selects[1].location - selects[0].location;
    //            offset2 = selects[2].location - selects[0].location;

    //            bool[] detect = detectDir(offset1);
    //            xSort = detect[0];
    //            zSort = detect[1];

    //            if ( xSort )
    //            {
    //                if ( offset2.x * offset1.x <= 0 )
    //                {
    //                    Position temp = path[i - 2];
    //                    path[i - 2] = path[i - 1];
    //                    path[i - 1] = temp;
    //                }
    //            }
    //            else if ( zSort )
    //            {
    //                if ( offset2.z * offset1.z <= 0 )
    //                {
    //                    Position temp = path[i - 2];
    //                    path[i - 2] = path[i - 1];
    //                    path[i - 1] = temp;
    //                }
    //            }
    //        }
    //        else
    //        {
    //            i = path.Count - 1;
    //            selects[0] = path[i - 1];
    //            selects[1] = path[i];
    //            selects[2] = path[i - 2];

    //            offset1 = selects[1].location - selects[0].location;
    //            offset2 = selects[1].location - selects[2].location;
    //            bool[] detect = detectDir(offset1);
    //            xSort = detect[0];
    //            zSort = detect[1];
    //            if ( xSort )
    //            {
    //                if ( offset2.x * offset1.x <= 0 )
    //                {
    //                    Position temp = path[i - 1];
    //                    path[i - 1] = path[i];
    //                    path[i] = temp;
    //                }
    //            }
    //            else if ( zSort )
    //            {
    //                if ( offset2.z * offset1.z <= 0 )
    //                {
    //                    Position temp = path[i - 1];
    //                    path[i - 1] = path[i];
    //                    path[i] = temp;
    //                }
    //            }
    //            break;
    //        }           
    //    }
    //    path.RemoveAt(path.Count - 1);
    //    //if ( path[1].location == group.Location )
    //    //{
    //    //    path.RemoveAt(0);
    //    //}       
    //}
    //private bool[] detectDir(Vector3 offset)
    //{
    //    bool[] detect = new bool[2];
    //    detect[0] = offset.x != 0;
    //    detect[1] = offset.z != 0;

    //    return detect;
    //}
}