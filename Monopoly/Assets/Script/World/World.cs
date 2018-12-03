using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World
{
    public Map map;
    private Group[] groupList;
    private int currentGroup;
    private int totalStep;
    private bool isRolled;
    private bool isFinded;

    public World()
    {
        map = new Map();
        //設定 4 個 group
        //讀檔?
        setGroupList();

        currentGroup = 0;
        isFinded = false;
        isRolled = false;
        totalStep = 1;
    }

    public Group CurrentGroup
    {
        get { return groupList[currentGroup]; }
    }

    public int TotalStep
    {
        get
        {
            return totalStep;
        }

        set
        {
            totalStep = value;
        }
    }



    public void playerAction()
    {
        switch ( groupList[currentGroup].State )
        {
            case PlayerState.rollingDice:
                isFinded = false;
                if (Input.GetButtonDown("Jump") && !isRolled )
                {
                    isRolled = true;
                    groupList[currentGroup].rollDice();
                }
                break;
            case PlayerState.findPath:
                isRolled = false;
                if ( !isFinded )
                {
                    isFinded = true;
                    groupList[currentGroup].findPathList(map ,totalStep);
                }
                break;
            case PlayerState.Walking:               
                groupList[currentGroup].move();
                break;

            case PlayerState.nextPlayer:
                CurrentGroup.State = PlayerState.rollingDice;
                currentGroup = ( currentGroup + 1 ) % Constants.PLAYERNUMBER;
                break;
        }
    }
    private void setGroupList()
    {
        groupList = new Group[Constants.PLAYERNUMBER];
        Direction[] playerDirection = new Direction [Constants.PLAYERNUMBER]{Direction.North ,Direction.East ,Direction.South ,Direction.West};
        int[] playerIndex = new int[Constants.PLAYERNUMBER]{2 * 30 + 2 ,2 * 30 + 27 ,27 * 30 + 2 ,27 * 30 + 27};
        Vector3[] playerLocation = new Vector3[Constants.PLAYERNUMBER]
                                      {map.BlockEntityList[2 * 30 + 2].Block.Location + new Vector3(0 ,0.2f ,0)
                                      ,map.BlockEntityList[2 * 30 + 27].Block.Location + new Vector3(0 ,0.2f ,0)
                                      ,map.BlockEntityList[27 * 30 + 2].Block.Location + new Vector3(0 ,0.2f ,0)
                                      ,map.BlockEntityList[27 * 30 + 27].Block.Location + new Vector3(0 ,0.2f ,0)};

        for ( int i = 0 ; i < Constants.PLAYERNUMBER ; i++ )
        {
            groupList[i] = new Group(null
                                    ,createActors(playerLocation[i] ,"Player1")
                                    ,new Attributes(20 ,20 ,20)
                                    ,new Resource()
                                    ,playerLocation[i]
                                    ,playerIndex[i]
                                    ,playerDirection[i]);
        }
    }
    private Actor[] createActors(Vector3 location ,string name)
    {
        Actor[] actors = new Actor[Constants.ACTORTOTALNUM];
        for ( int i = 0 ; i < Constants.ACTORTOTALNUM ; i++ )
        {
            actors[i] = new Actor(this ,name ,null ,createDice() ,location);
        }

        return actors;
    }
    private Dice createDice()
    {
        return new Dice(new int[6]);
    }
}
