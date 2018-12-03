using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class World
{
    public Map map;
    private Group[] groupList;
    private int currentGroup;


    public World()
    {
        string json = File.ReadAllText(@"C:\Users\kevin\Documents\unity3d-Monopoly\Monopoly\Assets\Resources\Texture\map.xsa");
        map = JsonConvert.DeserializeObject<Map>(json);
        
        map.build();
        //設定 4 個 group
        //讀檔?
        setGroupList();

        currentGroup = 0;
    }

    public Group CurrentGroup
    {
        get { return groupList[currentGroup]; }
    }

    public void playerAction()
    {
        switch ( groupList[currentGroup].State )
        {
            case PlayerState.Walking:
                groupList[currentGroup].move();
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
            actors[i] = new Actor(name ,null ,createDice() ,location);
        }

        return actors;
    }
    private Dice createDice()
    {
        return new Dice(new int[6]);
    }
}
