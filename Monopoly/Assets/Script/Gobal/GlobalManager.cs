using Newtonsoft.Json;
using System.IO;
using UnityEngine;

public class GlobalManager
{
    public Map map;
    private Group[] groupList;

    private int currentGroupIndex;
    private int totalStep;
    private GameState gameState;

    private DisplayManager displayManager;


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



    public GlobalManager()
    {
        string path = Directory.GetCurrentDirectory();
        string target = @"\Assets\Resources\Map\MonopolyMap.json";
        string json = File.ReadAllText(path + target);

        map = JsonConvert.DeserializeObject<Map>(json);
        map.build();
        setGroupList();

        currentGroupIndex = 0;
        totalStep = 1;
        gameState = GameState.GlobalEvent;

        displayManager = new DisplayManager(this);/////
    }


    public void execute()
    {
        switch ( gameState )
        {
            case GameState.GlobalEvent:
                gameState = GameState.PersonalEvent;
                //

                break;
            case GameState.PersonalEvent:
                groupList[currentGroupIndex].State = PlayerState.SearchPath;
                //
                gameState = GameState.PlayerMovement;
                CurrentPlayer.State = PlayerState.RollingDice;
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
                                //交給displayManager
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
                            //CurrentPlayer.State = PlayerState.Wait;


                            break;
                        case PlayerState.End:
                            //block.StopAction
                            CurrentPlayer.State = PlayerState.Wait;
                            gameState = GameState.End;//temp

                            break;
                        case PlayerState.Wait:
                            //等待
                            break;
                    }
                }
                break;
            case GameState.End:
                currentGroupIndex = ( currentGroupIndex + 1 ) % Constants.PLAYERNUMBER;
                groupList[currentGroupIndex].State = PlayerState.Normal;///
                gameState = GameState.GlobalEvent;

                //isFinded = false;
                //isRolled = false;
                break;
            case GameState.Wait:
                //等待
                break;
        }
    }


    private void setGroupList()//設定 4 個 group//讀檔?
    {
        groupList = new Group[Constants.PLAYERNUMBER];
        Direction[] playerDirection = new Direction [Constants.PLAYERNUMBER]{Direction.North ,Direction.North ,Direction.South ,Direction.East};
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
