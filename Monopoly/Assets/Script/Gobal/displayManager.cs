using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

class DisplayManager
{
    public GameObject timeMsgPanel;
    private GlobalManager globalManager;
    private GameObject nextPlayerText;
    private GameObject pathListEntity;
    private GameObject eventCard;
    private GameObject strategyCard;
    private GameObject buildingArea;
    private GameObject canNotBuyCard;
    private GameObject playerSideMsgPanel;
    private GameObject worldMsgPanel;
    private GameObject blockInformation;
    private Camera     blockCamera;
    private GameObject diceDisplayPanel;
    private GameObject diceObj;



    private int timer;

    private string worldMsg;
    public int day;
    public bool displayEndMsg;

    public Group currentPlayer
    {
        get
        {
            return globalManager.CurrentPlayer;
        }
    }


    public DisplayManager(GlobalManager globalManager)
    {
        this.globalManager = globalManager;

        pathListEntity = new GameObject("pathListEntity");

        

        nextPlayerText = Resources.Load<GameObject>("PreFab/Ui/NextPlayerText");
        nextPlayerText = GameObject.Instantiate(nextPlayerText);
        nextPlayerText.transform.SetParent(GameObject.Find("Canvas").transform ,false);

        eventCard = Resources.Load<GameObject>("PreFab/Ui/EventCardDisplay"); //GameObject.Find("EventCardDisplay");
        eventCard = GameObject.Instantiate(eventCard);
        eventCard.transform.SetParent(GameObject.Find("Canvas").transform ,false);
        eventCard.SetActive(false);
        eventCard.GetComponent<EventCardController>().globalManager = globalManager;

        strategyCard = Resources.Load<GameObject>("PreFab/Ui/strategyCardDisplay"); //GameObject.Find("strategyCardDisplay");
        strategyCard = GameObject.Instantiate(strategyCard);
        strategyCard.transform.SetParent(GameObject.Find("Canvas").transform ,false);
        strategyCard.SetActive(false);
        strategyCard.GetComponent<StrategyCardController>().globalManager = globalManager;


        buildingArea = GameObject.Find("BuildingDisplayArea");
        buildingArea.SetActive(false);
        buildingArea.GetComponent<BuildingDisplayController>().globalManager = globalManager;

        canNotBuyCard = Resources.Load<GameObject>("PreFab/Ui/CanNotBuyCard"); //GameObject.Find("CanNotBuyCard");
        canNotBuyCard = GameObject.Instantiate(canNotBuyCard);
        canNotBuyCard.transform.SetParent(GameObject.Find("Canvas").transform ,false);
        canNotBuyCard.SetActive(false);
        canNotBuyCard.GetComponent<CanNotBuyCardController>().globalManager = globalManager;
        canNotBuyCard.GetComponent<CanNotBuyCardController>().buildingArea = buildingArea;

        playerSideMsgPanel = GameObject.Find("PlayerMsg");
        playerSideMsgPanel.GetComponent<PlayerSideMsgController>().globalManager = globalManager;

        worldMsgPanel = GameObject.Find("WorldMsg");
        worldMsgPanel.transform.Find("WorldMsgShow/TheWorldMsg").GetComponent<Text>().text = "";
        day = 0;

        timeMsgPanel = GameObject.Find("WorldTime");
        blockInformation = GameObject.Find("BlockInformation");
        blockCamera = GameObject.Find("BlockCamera").GetComponent<Camera>();


        diceDisplayPanel = Resources.Load<GameObject>("PreFab/Ui/DiceDisplay"); //GameObject.Find("CanNotBuyCard");
        diceDisplayPanel = GameObject.Instantiate(diceDisplayPanel);
        diceDisplayPanel.transform.SetParent(GameObject.Find("Canvas").transform ,false);
        diceDisplayPanel.SetActive(false);

        diceObj = GameObject.Find("DiceCheckZone");
        diceObj.GetComponent<DiceCheckZoneScript>().globalManager = globalManager;
        diceObj.GetComponent<DiceCheckZoneScript>().diceDisplayPanel = diceDisplayPanel;
    }



    public void setWorldMsg(string str ,bool clear = false)
    {
        worldMsg = clear ? str : "\n" + worldMsg + str;
    }
    public void displayRollingDice()
    {
        //呼叫扔骰子
        //globalManager.TotalStep = 24;//temp
        //currentPlayer.State = PlayerState.SearchPath;//temp

        //worldMsg += string.Format("\"{0}\"骰出了\"{1}\"\n" ,globalManager.CurrentPlayer.name ,globalManager.TotalStep);//temp
        diceObj.GetComponent<DiceCheckZoneScript>().canRolling = true;
        diceObj.GetComponent<DiceCheckZoneScript>().number = 0;
        diceObj.GetComponent<DiceCheckZoneScript>().rolling = false;
        diceDisplayPanel.SetActive(true);
    }
    public void displaySearchPath(Map map)
    {
        createScoutPathEntity(map);
        createInteractiveDot();
    }
    public void displayPlayerMovement()
    {
        currentPlayer.CurrentActor.run(currentPlayer.Location);
        displayBlockInfo(globalManager.map.BlockList[currentPlayer.CurrentBlockIndex]);

        if ( currentPlayer.Scout.totalStep == 0 )
        {
            currentPlayer.Scout.deleteDot(currentPlayer.Scout.choicePath[0]);//刪除走過的點
            if ( currentPlayer.Scout.choicePath.Count != 0 )
                currentPlayer.Scout.deleteDot(currentPlayer.Scout.choicePath[0]);//刪除走過的點
            //currentPlayer.CurrentActor.stop();

            currentPlayer.State = PlayerState.End;
        }
    }
    public void displayEvent(EventBase eventData ,GameState nextGameState)
    {
        if ( globalManager.IsComputer )
        {
            //globalManager.GameState = nextGameState;
            calWhoDead(nextGameState);
        }
        else
        {
            //顯示事件卡
            eventCard.transform.Find("EventTitle/EventTitleText").GetComponent<Text>().text = eventData.Name;
            eventCard.transform.Find("EventImage/EventImageShow").GetComponent<Image>().sprite = Resources.Load<Sprite>(eventData.Image);
            eventCard.transform.Find("EventDes/EventDesText").GetComponent<Text>().text = eventData.Detail;
            eventCard.GetComponent<EventCardController>().nextGameState = nextGameState;
            eventCard.SetActive(true);
        }
        setWorldMsg(eventData.Short_detail);
        displayPlayerInfo();///
    }
    public void displayStopAction(Block block ,GameState nextGameState)
    {
        if ( block is EventBlock )
        {
            EventBase eventData = null;
            if ( globalManager.IsComputer )
            {
                eventData = globalManager.Events.doEvent(Eventtype.Apes
                                                        ,new List<Group>(globalManager.GroupList)
                                                        ,globalManager.CurrentPlayer);
            }
            else
            {
                eventData = globalManager.Events.doEvent(Eventtype.Forest
                                                        ,new List<Group>(globalManager.GroupList)
                                                        ,globalManager.CurrentPlayer);
            }


            displayEvent(eventData ,nextGameState);
        }
        else if ( block is BuildingBlock )
        {
            BuildingBlock buildingBlock = (BuildingBlock)block;
            if ( buildingBlock.Building == null )
            {
                if ( globalManager.IsComputer )
                {
                    EventBase eventData = globalManager.Events.doEvent(Eventtype.Apes
                                                                      ,new List<Group>( globalManager.GroupList)
                                                                      ,globalManager.CurrentPlayer);
                    displayEvent(eventData ,nextGameState);
                }
                else
                {
                    //建造建築物
                    displayBuildConstructor(buildingBlock ,nextGameState);
                }
            }
            else
            {
                if ( buildingBlock.Landlord.Equals(globalManager.CurrentPlayer) )
                {
                    EventBase eventData = new DiplomaticEvent();
                    eventData.DoEvent(new List<Group>(globalManager.GroupList) ,globalManager.CurrentPlayer);

                    displayEvent(eventData ,nextGameState);
                }
                else
                {
                    strategyCard.GetComponent<StrategyCardController>().nextGameState = nextGameState;
                    strategyCard.SetActive(true);

                    if ( globalManager.IsComputer )
                    {
                        System.Random random = new System.Random();
                        int choise = (random.Next(100) + globalManager.GroupList[globalManager.GroupList.Length - 1].Attributes.diplomatic / 10);
                        choise /= 50;

                        if ( choise == 0 )
                        {
                            strategyCard.GetComponent<StrategyCardController>().attackButtonClick();
                        }
                        else
                        {
                            strategyCard.GetComponent<StrategyCardController>().diplomaticButtonClick();
                        }
                    }
                }
            }
        }


    }
    public void displayNextPlayer()
    {
        if (displayEndMsg)
        {
            displayWorldMsg();
            displayEndMsg = false;
        }

        int winner = 0;
        for(int i = 0 ; i < globalManager.GroupList.Length ; i++ )
        {
            if( globalManager.GroupList[i] != null)
            {
                winner++;
            }
        }
        if(winner == 1)
        {
            SceneManager.LoadScene("ShowEventScene");
            globalManager.GameState = GameState.Wait;//?
        }

        if ( timer % 500 == 0 )
        {
            bool now = nextPlayerText.activeSelf;
            nextPlayerText.SetActive(!now);
        }
        timer = ( timer + 10 ) % 500;

        if(globalManager.IsAuto)
        {
            nextPlayerText.SetActive(false);
            globalManager.nextPlayer();
        }
        else
        {
            if ( Input.anyKey )
            {
                nextPlayerText.SetActive(false);
                globalManager.nextPlayer();
            }
        }
    }

    public void displayPlayerInfo(List<Faction> factionList = null)
    {
        playerSideMsgPanel.GetComponent<PlayerSideMsgController>().displayPlayerList(globalManager.GroupList ,factionList);
    }
    public void displayBuildConstructor(BuildingBlock buildingBlock ,GameState nextGameState)
    {
        buildingArea.GetComponent<BuildingDisplayController>().currentBuildingBlock = buildingBlock;
        buildingArea.GetComponent<BuildingDisplayController>().nextGameState = nextGameState;
        buildingArea.SetActive(true);
    }
    public void displayCantNotBuy(GameState nextGameState)
    {
        canNotBuyCard.GetComponent<CanNotBuyCardController>().nextGameState = nextGameState;
        canNotBuyCard.SetActive(true);
    }
    public void displayWorldMsg()
    {
        //worldMsgPanel.transform.Find("WorldMsgShow/TheWorldMsg").GetComponent<Text>().text += worldMsg;
        worldMsgPanel.transform.Find("WorldMsgShow/TheWorldMsg").GetComponent<Control>().WriteText(worldMsg);
        //Vector2 v =  worldMsgPanel.transform.Find("WorldMsgShow/TheWorldMsg").GetComponent<RectTransform>().sizeDelta;
        //worldMsgPanel.transform.Find("WorldMsgShow/TheWorldMsg").GetComponent<RectTransform>().sizeDelta = new Vector2(v.x, v.y + 30);
    }

    public void displayBlockInfo(Block block)
    {
        block.setLyer("CurrentBlock");
        blockCamera.transform.position = block.Location + new Vector3(0 ,10 ,0);//temp

        Text text =  blockInformation.transform.Find("BlockT1/BlockPlayer/BlockPlayerText").GetComponent<Text>();
        if(block is BuildingBlock)
        {
            BuildingBlock buildingBlock = (BuildingBlock)block;
            if( buildingBlock.Landlord == null)
            {
                text.text = "noMan";
            }
            else
            {
                text.text = buildingBlock.Landlord.name;
            }      
        }
        else
        {
            text.text = "noMan";
        }
    }

    /*==========private==========*/
    /*==========ScoutPathEntity==========*/
    private void createScoutPathEntity(Map map)
    {
        int[] markMap  = new int[map.BlockList.Length];
        //int[] duplicateMap  = new int[map.BlockList.Length];
        for ( int i = 0 ; i < markMap.Length ; i++ ) { markMap[i] = 0; }//全部標記為 "未走過"

        Position onePos;
        for ( int i = 0 ; i < currentPlayer.Scout.pathList.Count ; i++ )
        {
            //for ( int k = 0 ; k < map.BlockList.Length ; k++ )
            //{
            //    duplicateMap[k] = 0;
            //}

            for ( int j = 0 ; j < currentPlayer.Scout.pathList[i].Count ; j++ )
            {
                onePos = currentPlayer.Scout.pathList[i][j];
                if ( onePos.entity == null )
                {
                    if ( markMap[onePos.blockIndex] == 0 || ( markMap[onePos.blockIndex] == 1 && onePos.block is BuildingBlock &&
                        ( (BuildingBlock)onePos.block ).PathLocations.Count > 1 ) )
                    {
                        markMap[onePos.blockIndex]++;
                        buildEntity(onePos ,onePos.blockIndex ,markMap[onePos.blockIndex]);
                        onePos.entity.transform.parent = pathListEntity.transform;//統一放到一個Empty的GameObject下面
                    }
                    else
                    {
                        try
                        {
                            //duplicateMap[onePos.blockIndex]++;
                            //onePos.entity = pathListEntity.transform.Find("dot" + onePos.blockIndex + "-" + duplicateMap[onePos.blockIndex]).gameObject;//如果有了就不要再建造一次 直接指定
                            GameObject gameObject1 = pathListEntity.transform.Find("dot" + onePos.blockIndex + "-1").gameObject;
                            //GameObject gameObject2 = pathListEntity.transform.Find("dot" + onePos.blockIndex + "-2").gameObject;
                            if(gameObject1.transform.position.x == onePos.location.x && gameObject1.transform.position.z == onePos.location.z)
                            {
                                onePos.entity = gameObject1;
                            }
                            else
                            {
                                onePos.entity = pathListEntity.transform.Find("dot" + onePos.blockIndex + "-2").gameObject;
                            }
                            //if ( onePos.block is BuildingBlock && ( (BuildingBlock)onePos.block ).PathLocations.Count > 1 )
                            //{
                            //    duplicateMap[onePos.blockIndex] %= 2;
                            //}
                            //else
                            //{
                            //    duplicateMap[onePos.blockIndex] = 0;
                            //}
                        }
                        catch
                        {
                            Debug.Log("test");
                        }
                    }
                }
                //if ( ( markType[onePos.blockIndex] == -1 || markType[onePos.blockIndex] == i ) && markMap[onePos.blockIndex] < 2 )//if沒有建過 "這一個點"
                //{
                //    markMap[onePos.blockIndex]++;
                //    markType[onePos.blockIndex] = i;

                //    buildEntity(onePos ,onePos.blockIndex ,markMap[onePos.blockIndex]);
                //    onePos.entity.transform.parent = pathListEntity.transform;//統一放到一個Empty的GameObject下面
                //}
                //else
                //{
                //    try
                //    {
                //        //markMap[onePos.blockIndex]++;
                //        markMap[onePos.blockIndex] = markMap[onePos.blockIndex] % 2 + 1;
                //        onePos.entity = pathListEntity.transform.Find("dot" + onePos.blockIndex + "-" + markMap[onePos.blockIndex]).gameObject;//如果有了就不要再建造一次 直接指定
                //    }
                //    catch
                //    {
                //    }
                //}
            }
        }
    }
    private void buildEntity(Position onePos ,int mapIndex ,int offset)
    {
        onePos.entity = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        onePos.entity.transform.name = "dot" + mapIndex + "-" + offset;
        onePos.entity.transform.localScale = new Vector3(0.8f ,0.1f ,0.8f);

        onePos.entity.GetComponent<Renderer>().material = Resources.Load<Material>("Texture/Orange");

        onePos.entity.transform.position = ( onePos.location + new Vector3(0 ,0.2f ,0) );
        if (mapIndex == 62)
        {
            Debug.Log(onePos.location);
        }
    }
    private void createInteractiveDot()
    {
        int count = 0;
        foreach ( List<Position> onePath in currentPlayer.Scout.pathList )
        {
            GameObject entity = onePath[onePath.Count - 1].entity;

            if ( entity.GetComponent<PositionController>() == null )
            {
                entity.AddComponent<PositionController>();
                entity.GetComponent<PositionController>().pathNo = count;
                entity.GetComponent<PositionController>().CheckOut = currentPlayer.Scout.checkOutPath;
                entity.GetComponent<PositionController>().Select = currentPlayer.Scout.selectPath;
                entity.GetComponent<PositionController>().Leave = currentPlayer.Scout.leavePath;
                entity.transform.localScale = new Vector3(2f ,0.1f ,2f);
            }
            count++;
        }
        //if ( currentPlayer.Scout.pathList.Count == 1 )
        //{
        //    currentPlayer.Scout.checkOutPath(0);
        //}

        if ( globalManager.IsComputer )
        {
            System.Random random = new System.Random();
            int r = random.Next(currentPlayer.Scout.pathList.Count);

            currentPlayer.Scout.checkOutPath(r);
        }
    }

    private void calWhoDead(GameState nextGameState)
    {
        GameState gameState = (globalManager.CurrentPlayer.Resource.civilian <= 0)? GameState.End : nextGameState;

        List<Group> removeGroup = new List<Group>();
        foreach ( Group group in globalManager.GroupList )
        {
            if ( group.Resource.civilian <= 0 )
            {
                removeGroup.Add(group);
            }
        }
        for ( int i = 0 ; i < removeGroup.Count ; i++ )
        {
            for ( int j = 0 ; j < globalManager.GroupList.Length ; j++ )
            {
                if ( removeGroup[i].Equals(globalManager.GroupList[j]) )
                {
                    globalManager.GroupList[j] = null;
                    break;
                }
            }
        }

        int winner = 0;
        for ( int i = 0 ; i < globalManager.GroupList.Length ; i++ )
        {
            if ( globalManager.GroupList[i] != null )
            {
                winner++;
            }
        }

        globalManager.GameState = winner == 1 ? GameState.End : gameState;
    }
}

