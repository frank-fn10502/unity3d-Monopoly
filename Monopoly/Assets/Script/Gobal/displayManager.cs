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

    public Group CurrentPlayer
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
        nextPlayerText.SetActive(false);
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



    public void displayWorldMsg(string str ,bool clear = false)
    {
        worldMsg = clear ? str : worldMsg + str + "\n";
        if ( worldMsg != "" )
        {
            displayWorldMsg();
            worldMsg = "";
        }
    }
    public void displayRollingDice()
    {
        if ( globalManager.IsComputer )
        {
            globalManager.TotalStep = new System.Random().Next(5 ,25);
            CurrentPlayer.State = PlayerState.SearchPath;
        }
        else
        {
            diceObj.GetComponent<DiceCheckZoneScript>().canRolling = true;
            diceObj.GetComponent<DiceCheckZoneScript>().number = 0;
            diceObj.GetComponent<DiceCheckZoneScript>().rolling = false;
            diceDisplayPanel.SetActive(true);
        }
    }
    public void displaySearchPath(Map map)
    {
        displayWorldMsg(string.Format("{0}移動{1}" ,CurrentPlayer.name ,globalManager.TotalStep));

        createScoutPathEntity(map);
        createInteractiveDot();
    }
    public void displayPlayerMovement()
    {
        CurrentPlayer.CurrentActor.run(CurrentPlayer.Location);

        if ( CurrentPlayer.Scout.totalStep == 0 )
        {
            CurrentPlayer.Scout.deleteDot(CurrentPlayer.Scout.choicePath[0]);//刪除走過的點
            if ( CurrentPlayer.Scout.choicePath.Count != 0 )
                CurrentPlayer.Scout.deleteDot(CurrentPlayer.Scout.choicePath[0]);//刪除走過的點

            CurrentPlayer.State = PlayerState.End;
        }
    }
    public void displayEvent(EventBase eventData ,GameState nextGameState)
    {
        displayWorldMsg(eventData.Short_detail);
        eventCard.transform.Find("EventTitle/EventTitleText").GetComponent<Text>().text = eventData.Name;
        eventCard.transform.Find("EventImage/EventImageShow").GetComponent<Image>().sprite = Resources.Load<Sprite>(eventData.Image);
        eventCard.transform.Find("EventDes/EventDesText").GetComponent<Text>().text = eventData.Detail;
        eventCard.GetComponent<EventCardController>().nextGameState = nextGameState;
        eventCard.GetComponent<EventCardController>().detection = true;
        eventCard.SetActive(true);
        
        displayPlayerInfo();
    }
    public void displayStopAction(Block block ,GameState nextGameState)
    {
        if ( block is EventBlock )
        {
            Eventtype eventtype = ( globalManager.CurrentGroupIndex == globalManager.GroupList.Length - 1 ) ? Eventtype.Apes :Eventtype.Forest;
            EventBase eventData = globalManager.Events.doEvent(eventtype ,globalManager.createList() ,globalManager.CurrentPlayer);

            displayEvent(eventData ,nextGameState);
        }
        else if ( block is BuildingBlock )
        {
            BuildingBlock buildingBlock = (BuildingBlock)block;
            if ( buildingBlock.Building == null )
            {
                if ( globalManager.CurrentGroupIndex == globalManager.GroupList.Length - 1 && globalManager.IsComputer )
                {
                    EventBase eventData = globalManager.Events.doEvent(Eventtype.Apes,globalManager.createList(),globalManager.CurrentPlayer);
                    displayEvent(eventData ,nextGameState);
                }
                else
                {
                    buildingArea.GetComponent<BuildingDisplayController>().currentBuildingBlock = buildingBlock;
                    buildingArea.GetComponent<BuildingDisplayController>().nextGameState = nextGameState;
                    buildingArea.GetComponent<BuildingDisplayController>().detection = true;
                    buildingArea.SetActive(true);                 
                }
            }
            else
            {
                if ( buildingBlock.Landlord.Equals(globalManager.CurrentPlayer) )
                {
                    EventBase eventData = new DiplomaticEvent();
                    eventData.DoEvent(globalManager.createList() ,globalManager.CurrentPlayer);

                    displayEvent(eventData ,nextGameState);
                }
                else
                {                 
                    strategyCard.GetComponent<StrategyCardController>().nextGameState = nextGameState;
                    strategyCard.GetComponent<StrategyCardController>().detection = true;
                    strategyCard.SetActive(true);                    
                }
            }
        }


    }
    public void displayNextPlayer()
    {
        int winner = 0;
        for ( int i = 0 ; i < globalManager.GroupList.Length ; i++ )
        {
            if ( globalManager.GroupList[i] != null )
            {
                winner++;
            }
        }
        if ( winner == 1 )
        {
            SceneManager.LoadScene("ShowEventScene");
        }

        if ( timer % 500 == 0 )
        {
            bool now = nextPlayerText.activeSelf;
            nextPlayerText.SetActive(!now);
        }
        timer = ( timer + 10 ) % 500;

        if ( globalManager.IsAuto || Input.anyKey )
        {
            nextPlayerText.SetActive(false);
            globalManager.nextPlayer();
        }
    }

    public void displayPlayerInfo(List<Faction> factionList = null)
    {
        playerSideMsgPanel.GetComponent<PlayerSideMsgController>().displayPlayerList(globalManager.GroupList ,factionList);
    }
    public void displayCantNotBuy(GameState nextGameState)
    {
        canNotBuyCard.GetComponent<CanNotBuyCardController>().nextGameState = nextGameState;
        canNotBuyCard.SetActive(true);
    }
    public void displayBlockInfo(Block block)
    {
        block.setLyer("CurrentBlock");
        blockCamera.transform.position = block.Location + new Vector3(0 ,10 ,0);//temp

        Text text =  blockInformation.transform.Find("BlockT1/BlockPlayer/BlockPlayerText").GetComponent<Text>();
        if ( block is BuildingBlock )
        {
            BuildingBlock buildingBlock = (BuildingBlock)block;
            if ( buildingBlock.Landlord == null )
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
    private void displayWorldMsg()
    {
        //worldMsgPanel.transform.Find("WorldMsgShow/TheWorldMsg").GetComponent<Text>().text += worldMsg;
        worldMsgPanel.transform.Find("WorldMsgShow/TheWorldMsg").GetComponent<Control>().WriteText(worldMsg);
        //Vector2 v =  worldMsgPanel.transform.Find("WorldMsgShow/TheWorldMsg").GetComponent<RectTransform>().sizeDelta;
        //worldMsgPanel.transform.Find("WorldMsgShow/TheWorldMsg").GetComponent<RectTransform>().sizeDelta = new Vector2(v.x, v.y + 30);
    }

    /*==========ScoutPathEntity==========*/
    private void createScoutPathEntity(Map map)
    {
        int[] markMap  = new int[map.BlockList.Length];
        //int[] duplicateMap  = new int[map.BlockList.Length];
        for ( int i = 0 ; i < markMap.Length ; i++ ) { markMap[i] = 0; }//全部標記為 "未走過"

        Position onePos;
        for ( int i = 0 ; i < CurrentPlayer.Scout.pathList.Count ; i++ )
        {
            //for ( int k = 0 ; k < map.BlockList.Length ; k++ )
            //{
            //    duplicateMap[k] = 0;
            //}

            for ( int j = 0 ; j < CurrentPlayer.Scout.pathList[i].Count ; j++ )
            {
                onePos = CurrentPlayer.Scout.pathList[i][j];
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
                            if ( gameObject1.transform.position.x == onePos.location.x && gameObject1.transform.position.z == onePos.location.z )
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

    }
    private void createInteractiveDot()
    {
        int count = 0;
        foreach ( List<Position> onePath in CurrentPlayer.Scout.pathList )
        {
            GameObject entity = onePath[onePath.Count - 1].entity;

            if ( entity.GetComponent<PositionController>() == null )
            {
                entity.AddComponent<PositionController>();
                entity.GetComponent<PositionController>().pathNo = count;
                entity.GetComponent<PositionController>().CheckOut = CurrentPlayer.Scout.checkOutPath;
                entity.GetComponent<PositionController>().Select = CurrentPlayer.Scout.selectPath;
                entity.GetComponent<PositionController>().Leave = CurrentPlayer.Scout.leavePath;
                entity.transform.localScale = new Vector3(2f ,0.1f ,2f);
            }
            count++;
        }
        if ( globalManager.IsComputer )
        {
            System.Random random = new System.Random();
            int r = random.Next(CurrentPlayer.Scout.pathList.Count);

            CurrentPlayer.Scout.checkOutPath(r);
        }
    }
}

