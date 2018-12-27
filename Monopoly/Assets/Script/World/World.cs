using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


//public class MyCustomSerializationBinder : ISerializationBinder
//{
//    public Type BindToType(string assemblyName ,string typeName)
//    {
//        return Type.GetType(typeName);
//    }

//    public void BindToName(Type serializedType ,out string assemblyName ,out string typeName)
//    {
//        assemblyName = null;
//        typeName = serializedType.Name;
//    }
//}

public class World
{
    public Map map;
    private Group[] groupList;
    private int currentGroup;
    private int totalStep;
    private bool isRolled;
    private bool isFinded;

    private GameState gameState;///

    public World()
    {
        string path = Directory.GetCurrentDirectory();
        string target = @"\Assets\Resources\Map\MonopolyMap.json";
        string json = File.ReadAllText(path + target);

        map = JsonConvert.DeserializeObject<Map>(json);
        map.build();
        setGroupList();

        currentGroup = 0;
        isFinded = false;
        isRolled = false;
        totalStep = 1;
        gameState = GameState.GlobalEvent;
    }

    public Group CurrentGroup
    {
        get { return groupList[currentGroup]; }
    }
    public int TotalStep
    {
        get { return totalStep; }
        set { totalStep = value; }
    }
    public GameState GameState
    {
        get
        {
            return gameState;
        }
        set
        {
            gameState = value;
        }
    }

    public void execute()
    {
        switch ( gameState )
        {
            case GameState.GlobalEvent:
                gameState = GameState.PersonalEvent;
                break;
            case GameState.PersonalEvent:
                gameState = GameState.RollingDice;
                groupList[currentGroup].State = PlayerState.SearchPath;
                break;
            case GameState.RollingDice:
                if ( Input.GetButtonDown("Jump") && !isRolled )
                {                    
                    isRolled = true;
                    groupList[currentGroup].rollDice();
                }
                break;
            case GameState.PlayerMovement:
                {
                    switch ( groupList[currentGroup].State )
                    {
                        case PlayerState.SearchPath:
                            if ( !isFinded )
                            {                            
                                isFinded = true;
                                groupList[currentGroup].findPathList(map ,totalStep);
                            }
                            break;
                        case PlayerState.Walking:
                            groupList[currentGroup].move();
                            break;
                        case PlayerState.Stop:
                            //bloack.StopAction
                            gameState = GameState.End;//temp
                            break;
                    }
                }
                break;
            case GameState.End:
                currentGroup = ( currentGroup + 1 ) % Constants.PLAYERNUMBER;
                groupList[currentGroup].State = PlayerState.Normal;///
                gameState = GameState.GlobalEvent;

                isFinded = false;
                isRolled = false;
                break;
        }
    }


    private void setGroupList()//設定 4 個 group//讀檔?
    {
        groupList = new Group[Constants.PLAYERNUMBER];
        Direction[] playerDirection = new Direction [Constants.PLAYERNUMBER]{Direction.West ,Direction.North ,Direction.South ,Direction.East};
        int[] playerIndex = new int[Constants.PLAYERNUMBER]{2 * 30 + 2 ,2 * 30 + 27 ,27 * 30 + 2 ,27 * 30 + 27};
        Vector3[] playerLocation = new Vector3[Constants.PLAYERNUMBER]
                                      {map.BlockList[2 * 30 + 2].Location + new Vector3(0 ,0.2f ,0)
                                      ,map.BlockList[2 * 30 + 27].Location + new Vector3(0 ,0.2f ,0)
                                      ,map.BlockList[27 * 30 + 2].Location + new Vector3(0 ,0.2f ,0)
                                      ,map.BlockList[27 * 30 + 27].Location + new Vector3(0 ,0.2f ,0)};

        for ( int i = 0 ; i < Constants.PLAYERNUMBER ; i++ )
        {
            groupList[i] = new Group(null
                                    ,createActors(playerLocation[i] ,"Player1" ,playerDirection[i])
                                    ,new Attributes(20 ,20 ,20)
                                    ,new Resource()
                                    ,playerLocation[i]
                                    ,playerIndex[i]
                                    ,playerDirection[i]);
        }
    }
    private Actor[] createActors(Vector3 location ,string name ,Direction enterDirection)
    {
        Actor[] actors = new Actor[Constants.ACTORTOTALNUM];
        for ( int i = 0 ; i < Constants.ACTORTOTALNUM ; i++ )
        {
            actors[i] = new Actor(this ,name ,null ,createDice() ,location ,enterDirection);
        }

        return actors;
    }
    private Dice createDice()
    {
        return new Dice(new int[6]);
    }
}
