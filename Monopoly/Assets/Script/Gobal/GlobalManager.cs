using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GlobalManager
{
    public Map map;
    private Group[] groupList;

    private int currentGroupIndex;
    private int totalStep;
    private bool isRolled;
    private bool isFinded;
    private GameState gameState;

    private DisplayManager displayManager;
    private Event events;


    public Group CurrentPlayer
    {
        get { return groupList[currentGroupIndex]; }
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

    public GlobalManager(List<Faction> factionList = null)
    {
        string path = Directory.GetCurrentDirectory();
        string target = @"\Assets\Resources\Map\MonopolyMap.json";
        string json = File.ReadAllText(path + target);

        map = JsonConvert.DeserializeObject<Map>(json);
        map.build();

        List<Faction> factions;
        if(factionList == null)
        {
            target = @"\Assets\Resources\Faction\MonopolyFaction.json";
            json = File.ReadAllText(path + target);
            factions = JsonConvert.DeserializeObject<List<Faction>>(json);
        }
        else
        {
            factions = factionList;
        }
        setGroupList(factions);

        currentGroupIndex = 0;
        totalStep = 1;
        gameState = GameState.GlobalEvent;

        displayManager = new DisplayManager(this);
        events = new Event();
    }

    public void execute()
    {
        switch ( gameState )
        {
            case GameState.GlobalEvent:
                if(currentGroupIndex % groupList.Length == 0)
                {
                    //抽世界事件
                    EventBase eventData = events.doEvent(Eventtype.Word ,new List<Group>(groupList) ,CurrentPlayer);                    
                    gameState = GameState.Wait;
                    displayManager.displayEvent(eventData ,GameState.PersonalEvent);
                }
                else
                {
                    gameState = GameState.PersonalEvent;
                }
                CurrentPlayer.State = PlayerState.RollingDice;
                
                //gameState = GameState.PersonalEvent;//temp

                break;
            case GameState.PersonalEvent:
                if ( CurrentPlayer.InJailTime == 0 )
                {
                    //抽個人事件
                    EventBase eventData = events.doEvent(Eventtype.Personal ,new List<Group>(groupList) ,CurrentPlayer);                   
                    gameState = GameState.Wait;
                    displayManager.displayEvent(eventData ,GameState.PlayerMovement);
                }
                else
                {
                    gameState = GameState.PlayerMovement;
                }
                //gameState = GameState.PlayerMovement;//temp

                break;
            case GameState.PlayerMovement:
                {
                    switch ( groupList[currentGroupIndex].State )
                    {
                        case PlayerState.RollingDice:
                            if ( Input.GetButtonDown("Jump") )
                            {
                                //groupList[currentGroupIndex].rollDice();
                                CurrentPlayer.State = PlayerState.Wait;
                                displayManager.displayRollingDice();//轉換到下一個階段
                            }
                            break;
                        case PlayerState.SearchPath:
                            groupList[currentGroupIndex].findPathList(map ,totalStep);
                            CurrentPlayer.State = PlayerState.Wait;
                            displayManager.displaySearchPath(map);                          

                            break;
                        case PlayerState.Walking:
                            groupList[currentGroupIndex].move();
                            displayManager.displayPlayerMovement();                           

                            break;
                        case PlayerState.End:
                            //block.StopAction
                            CurrentPlayer.State = PlayerState.Wait;
                            //交給displayManager

                            gameState = GameState.End;//temp

                            break;
                        case PlayerState.InJail:
                            CurrentPlayer.InJailTime--;
                            gameState = GameState.End;//直接結束

                            break;
                        case PlayerState.Wait:
                            //等待
                            break;
                    }
                }
                break;
            case GameState.End:
                CurrentPlayer.State = PlayerState.Wait;
                //交給displayManager
                displayManager.displayNextPlayer();

                break;
            case GameState.Wait:
                //等待
                break;
        }
    }
    public void nextPlayer()
    {
        currentGroupIndex = ( currentGroupIndex + 1 ) % Constants.PLAYERNUMBER;
        gameState = GameState.GlobalEvent;
    }

    private void setGroupList(List<Faction> factions)
    {
        groupList = new Group[Constants.PLAYERNUMBER];
        Direction[] playerDirection = new Direction [Constants.PLAYERNUMBER]{Direction.North ,Direction.East ,Direction.South ,Direction.West};
        int[] playerIndex = new int[Constants.PLAYERNUMBER]{2 * 30 + 2 ,2 * 30 + 27 ,27 * 30 + 27 ,27 * 30 + 2};

        int i = 0;
        foreach (Faction faction in factions)
        {
            groupList[i] = new Group(map.BlockList
                                    ,null
                                    ,faction.actorList.ToArray()
                                    ,new Attributes(faction.attributes)
                                    ,new Resource(faction.resource)
                                    ,map.BlockList[playerIndex[i]].standPoint()//?
                                    ,playerIndex[i]//?
                                    ,playerDirection[i]);//?
            groupList[i].CurrentActor.build(groupList[i].Location ,playerDirection[i]);
            i++;
            if ( i >= Constants.PLAYERNUMBER ) break;//temp
        }
    }
    /*暫時*/
    //private void setGroupList()//設定 4 個 group//讀檔?
    //{
    //    groupList = new Group[Constants.PLAYERNUMBER];
    //    Direction[] playerDirection = new Direction [Constants.PLAYERNUMBER]{Direction.North ,Direction.North ,Direction.South ,Direction.East};
    //    int[] playerIndex = new int[Constants.PLAYERNUMBER]{2 * 30 + 2 ,2 * 30 + 27 ,27 * 30 + 2 ,27 * 30 + 27};
    //    Vector3[] playerLocation = new Vector3[Constants.PLAYERNUMBER]
    //                                  {map.BlockList[2 * 30 + 2].Location + new Vector3(0 ,0.2f ,0)
    //                                  ,map.BlockList[2 * 30 + 27].Location + new Vector3(0 ,0.2f ,0)
    //                                  ,map.BlockList[27 * 30 + 2].Location + new Vector3(0 ,0.2f ,0)
    //                                  ,map.BlockList[27 * 30 + 27].Location + new Vector3(0 ,0.2f ,0)};

    //    for ( int i = 0 ; i < Constants.PLAYERNUMBER ; i++ )
    //    {
    //        groupList[i] = new Group(null
    //                                ,createActors(playerLocation[i] ,"Player1" ,playerDirection[i])
    //                                ,new Attributes(20 ,20 ,20)
    //                                ,new Resource()
    //                                ,playerLocation[i]
    //                                ,playerIndex[i]
    //                                ,playerDirection[i]);
    //    }
    //}
    //private Actor[] createActors(Vector3 location ,string name ,Direction enterDirection)
    //{
    //    Actor[] actors = new Actor[Constants.ACTORTOTALNUM];
    //    for ( int i = 0 ; i < Constants.ACTORTOTALNUM ; i++ )
    //    {
    //        actors[i] = new Actor(this ,name ,null ,createDice() ,location ,enterDirection);
    //    }

    //    return actors;
    //}
    //private Dice createDice()
    //{
    //    return new Dice(new int[6]);
    //}
}
